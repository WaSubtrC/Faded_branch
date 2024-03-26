using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath,  saveFileName); ;

        try
        {

            File.WriteAllText(path, json);
#if UNITY_EDITOR
            Debug.Log($"数据成功保存在: {path}");
#endif
        }
        catch (System.Exception excaption)
        {
#if UNITY_EDITOR
            Debug.LogError($"数据未能保存在: {path}\n{excaption}");
#endif
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
           
#if UNITY_EDITOR
            Debug.Log($"数据成功读取在: {path}");
#endif
            return data;
        }
        catch (System.Exception excaption)
        {
#if UNITY_EDITOR
            Debug.LogError($"数据未能读取: {path}\n{excaption}");
#endif

            return default;
        }
    }
public static void LoadFromJsonOverwrite<T>(string saveFileName, T savedData)
{
    var path = Path.Combine(Application.persistentDataPath,  saveFileName);
    try
    {
        var json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, savedData);

#if UNITY_EDITOR
        Debug.Log($"数据成功读取在: {path}");
#endif
    }
    catch (System.Exception exception)
    {
#if UNITY_EDITOR
        Debug.LogError($"数据未能读取: {path}\n{exception}");
#endif
    }
}



    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath,  saveFileName);

        try
        {
            File.Delete(path);
#if UNITY_EDITOR
            Debug.Log($"数据成功删除: {path}");
#endif
        }
        catch (System.Exception excaption)
        {
#if UNITY_EDITOR
            Debug.LogError($"数据未能删除: {path}.\n{excaption}");
#endif
        }
    }
}
