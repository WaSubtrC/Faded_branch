using UnityEngine;

public class SavaManager : Singleton<SavaManager>
{
    const string PLAYER_DATA_KEY = "PlayerData";
    const string PLAYER_DATA_FILE_NAME = "PlayerData.sav";
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.S)) { SavePlayerData(); }
        //if(Input.GetKeyUp(KeyCode.L)) { LoadPlayerData(); }
    }

    #region Saving Function

    //切换场景前记得使用save 以便数据不丢失保存下来
    //切换场景后记得使用Load 
    public void SavePlayerData() {  //仅仅保存玩家的数据   
        Save(PLAYER_DATA_FILE_NAME, GameManager.Instance.playerStats.characterData);
    }
    

    public void LoadPlayerData() {   
        Load(PLAYER_DATA_FILE_NAME, GameManager.Instance.playerStats.characterData);       
    }

    public void SaveInventoryData(){ 
        Save(InventoryManager.Instance.inventoryData.name, InventoryManager.Instance.inventoryData);
    }
    public void LoadInventoryData() { 
        Load(InventoryManager.Instance.inventoryData.name, InventoryManager.Instance.inventoryData);
    }
    #endregion

    #region Help Functions

    public void Save(string fileName,Object _data) 
    {
        SaveSystem.SaveByJson(fileName, _data);
    }
    public void Load( string fileName,Object _data) 
    {
        SaveSystem.LoadFromJsonOverwrite(fileName,_data);
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
    public static void DeletePlayerDataPrefs()
    {
        PlayerPrefs.DeleteKey(PLAYER_DATA_KEY);
    }

    [UnityEditor.MenuItem("Developer/Delete Player Data Save File")]
    public static void DeletePlayerDataSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
#endif
    #endregion


}
