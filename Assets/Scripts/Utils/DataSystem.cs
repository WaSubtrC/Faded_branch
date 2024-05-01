using System.IO;
using UnityEngine;


public static class DataSystem
{
    public static string dataDirectory = "/save";

    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.dataPath + dataDirectory,  saveFileName); ;

        try
        {

            File.WriteAllText(path, json);
#if UNITY_EDITOR
            Debug.Log($"���ݳɹ�������: {path}");
#endif
        }
        catch (System.Exception exception)
        {
#if UNITY_EDITOR
            Debug.LogError($"����δ�ܱ�����: {path}\n{exception}");
#endif
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.dataPath + dataDirectory, saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
           
#if UNITY_EDITOR
            Debug.Log($"���ݳɹ���ȡ��: {path}");
#endif
            return data;
        }
        catch (System.Exception exception)
        {
#if UNITY_EDITOR
            Debug.LogError($"����δ�ܶ�ȡ: {path}\n{exception}");
#endif
            GameManager.AppendLog($"����δ�ܶ�ȡ: {path}\n{exception}");
            return default;
        }
    }

    public static void LoadFromJsonOverwrite<T>(string saveFileName, T savedData)
    {
        var path = Path.Combine(Application.dataPath + dataDirectory,  saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, savedData);

#if UNITY_EDITOR
            Debug.Log($"���ݳɹ���ȡ��: {path}");
#endif
        }
        catch (System.Exception exception)
        {
#if UNITY_EDITOR
            Debug.LogError($"����δ�ܶ�ȡ: {path}\n{exception}");
#endif
            GameManager.AppendLog($"����δ�ܶ�ȡ: {path}\n{exception}");
        }
    }



    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.dataPath + dataDirectory,  saveFileName);

        try
        {
            File.Delete(path);
#if UNITY_EDITOR
            Debug.Log($"���ݳɹ�ɾ��: {path}");
#endif
        }
        catch (System.Exception excaption)
        {
#if UNITY_EDITOR
            Debug.LogError($"����δ��ɾ��: {path}.\n{excaption}");
#endif
            GameManager.AppendLog($"����δ��ɾ��: {path}.\n{excaption}");
        }
    }

    public static T DeepCopy<T>(T so) where T : ScriptableObject
    {
        if (so == null)
            return null;

        string json = JsonUtility.ToJson(so);
        T clone = ScriptableObject.CreateInstance<T>();
        JsonUtility.FromJsonOverwrite(json, clone);

        return clone;
    }
}
