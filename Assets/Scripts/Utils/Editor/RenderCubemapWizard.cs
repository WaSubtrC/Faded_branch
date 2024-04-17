using UnityEngine;
using UnityEditor;
using System.IO;

public class RenderCubemapWizard : ScriptableWizard
{
    public Transform viewPosition; // 观察位置(临时相机需要放置的位置)
    public Cubemap cubemap; // 生成的Cubemap

    [MenuItem("GameObject/Render Cubemap")]
    static void RenderCubemap()
    { // 选择菜单时回调
        ScriptableWizard.DisplayWizard<RenderCubemapWizard>("Render cubemap", "Render");
    }

    void OnWizardUpdate()
    { // 开启窗口或数据更新时回调
        helpString = "在观察位置处生成Cubemap和6面纹理";
        isValid = (viewPosition != null) && (cubemap != null);
    }

    void OnWizardCreate()
    { // 点击"Render"按钮时回调
        GameObject go = new GameObject("CubemapCamera");
        go.transform.position = viewPosition.position;
        Camera camera = go.AddComponent<Camera>();
        camera.RenderToCubemap(cubemap); // 生成cubemap
        DestroyImmediate(go);
        SaveCubemap2Png();
    }

    private void SaveCubemap2Png()
    { // 导出cubemap的6张纹理为png
        Texture2D texture2D = new Texture2D(cubemap.width, cubemap.height, TextureFormat.RGB24, false);
        Color[] flipColors = new Color[cubemap.width * cubemap.height];
        for (int i = 0; i < 6; i++)
        {
            CubemapFace face = (CubemapFace)i;
            Color[] colors = cubemap.GetPixels(face);
            FlipColors(colors, flipColors, cubemap.width, cubemap.height);
            texture2D.SetPixels(flipColors);
            string path = Application.dataPath + "/Resources/Materials/" + cubemap.name + "_" + face.ToString() + ".png";
            File.WriteAllBytes(path, texture2D.EncodeToPNG());
        }
        DestroyImmediate(texture2D);
    }

    private void FlipColors(Color[] colors, Color[] flipColors, int width, int height)
    { // 上下、左右翻转(或180°旋转)像素
        for (int i = 0; i < colors.Length; i++)
        {
            int x = width - 1 - i % width;
            int y = height - 1 - i / width;
            flipColors[i] = colors[y * width + x];
        }
    }
}