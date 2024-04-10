#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;



public class AddMeshCollider : EditorWindow
{
    [MenuItem("Tools/����Ƴ���ײ��")]

    public static void Open()
    {
        EditorWindow.GetWindow(typeof(AddMeshCollider));
    }
    void OnGUI()
    {
        if (GUILayout.Button("�����ײ��"))
        {
            Add();
        }

        if (GUILayout.Button("�Ƴ���ײ��"))
        {
            Remove();
        }
    }
    public static void Remove()
    {
        //Ѱ��Hierarchy��������е�MeshRenderer
        var tArray = Resources.FindObjectsOfTypeAll(typeof(MeshRenderer));
        for (int i = 0; i < tArray.Length; i++)
        {

            MeshRenderer t = tArray[i] as MeshRenderer;

            //���泡���޸ģ�����ִ�����ֶ�Ctrl+s����
            Undo.RecordObject(t, t.gameObject.name);

            MeshCollider meshCollider = t.gameObject.GetComponent<MeshCollider>();
            if (meshCollider != null)
            {
                DestroyImmediate(meshCollider);
            }

            //ˢ�³���
            EditorUtility.SetDirty(t);

        }
        Debug.Log("remove Succed");
    }

    public static void Add()
    {
        //Ѱ��Hierarchy��������е�MeshRenderer
        var tArray = Resources.FindObjectsOfTypeAll(typeof(MeshRenderer));

        for (int i = 0; i < tArray.Length; i++)
        {

            MeshRenderer t = tArray[i] as MeshRenderer;

            //���泡���޸ģ�����ִ�����ֶ�Ctrl+s����
            Undo.RecordObject(t, t.gameObject.name);

            MeshCollider meshCollider = t.gameObject.GetComponent<MeshCollider>();
            if (meshCollider == null)
            {
                t.gameObject.AddComponent<MeshCollider>();
            }

            //ˢ�³���
            EditorUtility.SetDirty(t);


        }
        Debug.Log("Add Succed");
    }
}

#endif