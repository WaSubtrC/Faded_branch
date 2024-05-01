using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Faded.Town;


public class DataManager : Singleton<DataManager>
{
    [System.Serializable]
    public class InventoryEntry
    {
        public string key;
        public InventoryData_SO value;

        public InventoryEntry(string k, InventoryData_SO v)
        {
            key = k;
            value = v;
        }

    }

    const string PLAYER_DATA_KEY = "PlayerStatus";
    const string PLAYER_DATA_FILE_NAME = "PlayerStatus.sav";
    string sceneName = "level";

    [Header("ChestData")]
    public List<InventoryEntry> chest_templates = new List<InventoryEntry>();
    public List<InventoryEntry> chests = new List<InventoryEntry>();


    public string SceneName {  get { return DataSystem.LoadFromJson<string> (sceneName); } }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.F3)) { Save(); }
        if (Input.GetKeyUp(KeyCode.F4)) { Load(); }
        */
    }

    #region Saving Function

    public void SavePlayerData() { 
        DataSystem.SaveByJson(PLAYER_DATA_FILE_NAME, GameManager.Instance.playerStats.playerData);
    }
    
    public void LoadPlayerData() {
        DataSystem.LoadFromJsonOverwrite(PLAYER_DATA_FILE_NAME, GameManager.Instance.playerStats.playerData);       
    }

    public void SaveInventoryData(){
        DataSystem.SaveByJson(InventoryManager.Instance.inventoryData.name, InventoryManager.Instance.inventoryData);
    }
    public void LoadInventoryData() {
        DataSystem.LoadFromJsonOverwrite(InventoryManager.Instance.inventoryData.name, InventoryManager.Instance.inventoryData);
    }

    public void SaveChestData()
    {
        foreach(var chest in chests)
        {
            DataSystem.SaveByJson(chest.key, chest.value);
        }
    }

    public void LoadChestData()
    {
        foreach (var chest in chests)
        {
            DataSystem.LoadFromJsonOverwrite(chest.key, chest.value);
        }
    }

    public void LoadChestTemplateData()
    {
        chests = new List<InventoryEntry>();
        foreach(var chest_template in chest_templates)
        {
            InventoryEntry tmp = new InventoryEntry(chest_template.key, Instantiate(chest_template.value));
            chests.Add(tmp);
        }
    }

    public void Save() 
    {
        SavePlayerData();
        SaveInventoryData();
        SaveChestData();
        DataSystem.SaveByJson(sceneName, SceneManager.GetActiveScene().name);   //保存当前场景
    }
    public void Load() 
    {
        LoadPlayerData();
        LoadInventoryData();
        LoadChestData();
    }
    #endregion

    #region Help Functions

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]//删除PlayerPrefs
    public static void DeletePlayerDataPrefs()
    {
        PlayerPrefs.DeleteKey(PLAYER_DATA_KEY);
    }

    [UnityEditor.MenuItem("Developer/Delete Player Data Save File")]//删除 存档文件
    public static void DeletePlayerDataSaveFile()
    {
        DataSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
#endif
    #endregion

    #region
    public InventoryData_SO getChestData(string key)
    {
        foreach(var chest in chests)
        {
            if (chest.key == key)
                return chest.value;
        }
        
#if UNITY_EDITOR
        Debug.Log("Key not found");
#endif
        return null;
        
    }
    #endregion

}
