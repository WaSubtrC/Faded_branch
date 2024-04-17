Shader "Custom/SceneTransitionShader"
{
    Properties
    {
        _ScreenWidth("ScreenWidth", Range(0, 4096)) = 1920
        _ScreenHeight("ScreenHeight", Range(0, 4096)) = 1080
        _Life("Life", Range(0, 1)) = 0
        [NoScaleOffset] _MainTex("MainTex", 2D) = "White"
        [NoScaleOffset] _TransTex("TransTex", 2D) = "White"
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200
        Cull Off

        Pass{

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _TransTex;
            float4 _TransTex_ST;

            float _Life;
            float _ScreenWidth;
            float _ScreenHeight;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
            };

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                _TransTex_ST.x = _Life * _Life * 100;
                _TransTex_ST.y = _TransTex_ST.x / _ScreenWidth * _ScreenHeight;
                _TransTex_ST.z = -_TransTex_ST.x / 2 + 0.5;
                _TransTex_ST.w = -_TransTex_ST.y / 2 + 0.5;
                o.uv = v.uv * _TransTex_ST.xy + _TransTex_ST.zw;
                o.uv2 = v.uv2;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target{
                fixed4 transColor = tex2D(_TransTex, i.uv);
                fixed4 mainColor = tex2D(_MainTex, i.uv2);
                mainColor.a = 1 - transColor.a;
                clip(mainColor.a - 0.001);
                return mainColor;
            }

            ENDCG

        }
    }
    
    FallBack "Diffuse"
}
