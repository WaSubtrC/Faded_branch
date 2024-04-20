using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : Singleton<DataManager>
{
    const string PLAYER_DATA_KEY = "PlayerStatus";
    const string PLAYER_DATA_FILE_NAME = "PlayerStatus.sav";
    string sceneName = "level";
    public string SceneName {  get { return DataSystem.LoadFromJson<string> (sceneName); } }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3)) { Save(); }
        if (Input.GetKeyUp(KeyCode.F4)) { Load(); }
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
    public void Save() 
    {
        SavePlayerData();
        SaveInventoryData();
        DataSystem.SaveByJson(sceneName, SceneManager.GetActiveScene().name);   //保存当前场景
    }
    public void Load() 
    {
        LoadPlayerData();
        LoadInventoryData();
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


}
