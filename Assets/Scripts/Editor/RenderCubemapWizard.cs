using UnityEngine;
using UnityEditor;
using System.IO;

public class RenderCubemapWizard : ScriptableWizard
{
    public Transform viewPosition; // �۲�λ��(��ʱ�����Ҫ���õ�λ��)
    public Cubemap cubemap; // ���ɵ�Cubemap

    [MenuItem("GameObject/Render Cubemap")]
    static void RenderCubemap()
    { // ѡ��˵�ʱ�ص�
        ScriptableWizard.DisplayWizard<RenderCubemapWizard>("Render cubemap", "Render");
    }

    void OnWizardUpdate()
    { // �������ڻ����ݸ���ʱ�ص�
        helpString = "�ڹ۲�λ�ô�����Cubemap��6������";
        isValid = (viewPosition != null) && (cubemap != null);
    }

    void OnWizardCreate()
    { // ���"Render"��ťʱ�ص�
        GameObject go = new GameObject("CubemapCamera");
        go.transform.position = viewPosition.position;
        Camera camera = go.AddComponent<Camera>();
        camera.RenderToCubemap(cubemap); // ����cubemap
        DestroyImmediate(go);
        SaveCubemap2Png();
    }

    private void SaveCubemap2Png()
    { // ����cubemap��6������Ϊpng
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
    { // ���¡����ҷ�ת(��180����ת)����
        for (int i = 0; i < colors.Length; i++)
        {
            int x = width - 1 - i % width;
            int y = height - 1 - i / width;
            flipColors[i] = colors[y * width + x];
        }
    }
}