using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : Singleton<SaveManager>
{
    const string PLAYER_DATA_KEY = "PlayerStatus";
    const string PLAYER_DATA_FILE_NAME = "PlayerStatus.sav";
    string sceneName = "level";
    public string SceneName {  get { return SaveSystem.LoadFromJson<string> (sceneName); } }

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

    //�л�����ǰ�ǵ�ʹ��save �Ա����ݲ���ʧ��������
    //�л�������ǵ�ʹ��Load 
    public void SavePlayerData() { 
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, GameManager.Instance.playerStats.playerData);
    }
    
    public void LoadPlayerData() {
        SaveSystem.LoadFromJsonOverwrite(PLAYER_DATA_FILE_NAME, GameManager.Instance.playerStats.playerData);       
    }

    public void SaveInventoryData(){
        SaveSystem.SaveByJson(InventoryManager.Instance.inventoryData.name, InventoryManager.Instance.inventoryData);
    }
    public void LoadInventoryData() {
        SaveSystem.LoadFromJsonOverwrite(InventoryManager.Instance.inventoryData.name, InventoryManager.Instance.inventoryData);
    }
    public void Save() 
    {
        SavePlayerData();
        SaveInventoryData();
        SaveSystem.SaveByJson(sceneName, SceneManager.GetActiveScene().name);   //���浱ǰ����
    }
    public void Load() 
    {
        LoadPlayerData();
        LoadInventoryData();
    }
    #endregion

    #region Help Functions


#if UNITY_EDITOR
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]//ɾ��PlayerPrefs
    public static void DeletePlayerDataPrefs()
    {
        PlayerPrefs.DeleteKey(PLAYER_DATA_KEY);
    }

    [UnityEditor.MenuItem("Developer/Delete Player Data Save File")]//ɾ�� �浵�ļ�
    public static void DeletePlayerDataSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
#endif
    #endregion


}
