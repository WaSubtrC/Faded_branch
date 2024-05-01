using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Faded.Town;


public class GameManager : Singleton<GameManager>
{
    public PlayerStatus playerStats;
    public GameObject player;

    [Header("Prefab")]
    public Transform pfChatBubble;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        player = GameObject.FindWithTag("Player");


        AppendLog("Start game at " + DateTime.Now.ToString());
    }

    private void Update()
    {

    }

    #region Atlas
    public void OnEnterTown()
    {
        MyLoadScene(Constants.TOWN_SCENE_NAME);

        player.GetComponent<PlayerController>().OnMoveToward(Constants.POINT_TOWN_ENTER);
        player.GetComponentInChildren<MainCamera>().OnTowardOutside();

        AudioManager.Instance.Switch("Town");

    }

    public void OnEnterHome()
    {
        MyLoadScene(Constants.HOME_SCENE_NAME);

        player.GetComponent<PlayerController>().OnMoveToward(Constants.POINT_HOME_ENTER);
        player.GetComponentInChildren<MainCamera>().OnTowardInside();

        AudioManager.Instance.Switch("Home");
    }



    /* TODO:
     *  1. Save data(player's position in town, playerAvatar's position on atlas)
     *  2. Load dungeon scene (init by layer¡¢level£¬level decides the basic stats of monster, this can be implemented later)
     *  3. Inherit data from PlayerStatus to Player
    */
    public void OnEnterDungeon()
    {
        MyLoadScene(Constants.DUNGEON_SCENE_NAME);
        AudioManager.Instance.Switch("Dungeon");
    }

    #endregion


    #region Menu
    public void StartNewGame()
    {
        MyLoadScene(Constants.TOWN_SCENE_NAME);
        StartCoroutine(OnStartNewGame());
    }

    IEnumerator OnStartNewGame()
    {
        //wait for at least 0.5s
        yield return new WaitForSeconds(0.5f);

        //init player pos
        Instance.player.GetComponentInChildren<MainCamera>().OnStartNewGame();
        Instance.player.GetComponent<PlayerController>().OnMoveToward(Constants.POINT_TOWN_BORN);

        UIManager.Instance.gameObject.SetActive(true);
        UIManager.Instance.SetUp();

        AtlasManager.Instance.OnTransPlace();

        AudioManager.Instance.Switch("Town");

        //init data
        DataManager.Instance.LoadChestTemplateData();
    }

    //TODO:save the current scene and pos of player
    public void ContinueGame()
    {
        MyLoadScene(Constants.TOWN_SCENE_NAME);
        StartCoroutine(OnContinueGame());
    }

    IEnumerator OnContinueGame()
    {
        yield return new WaitForSeconds(0.5f);
        Instance.player.GetComponentInChildren<MainCamera>().OnContinueGame();
        Instance.player.GetComponent<PlayerController>().OnMoveToward(Constants.POINT_TOWN_ENTER);

        UIManager.Instance.gameObject.SetActive(true);
        UIManager.Instance.SetUp();

        AtlasManager.Instance.OnTransPlace();

        AudioManager.Instance.Switch("Town");

        //init data
        try
        {
            DataManager.Instance.Load();
            InventoryManager.Instance.RefreshUI();
        }
        catch
        {
            AppendLog("Fail to load data");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        AppendLog("Quit game at " + DateTime.Now.ToString());
    }
    #endregion



    #region Scene
    public void RegisterPlayer(PlayerStatus player)
    {
        playerStats = player;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void MyLoadScene(string newSceneName)
    {
        //Before load scene
        string currSceneName = SceneManager.GetActiveScene().name;
        if (currSceneName == Constants.TOWN_SCENE_NAME ||
            currSceneName == Constants.HOME_SCENE_NAME)
            StartCoroutine(SaveBeforeLoad(newSceneName));
        else
            SceneManager.LoadScene(newSceneName);
    }

    //After load scene
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (player == null)
        {
            Debug.Log("find player");
            player = GameObject.FindWithTag("Player");
        }
        if (playerStats == null && player != null)
            playerStats = player.GetComponent<PlayerStatus>();

        string sceneName = scene.name;
        if (sceneName == Constants.MENU_SCENE_NAME)
        {
            if(player != null)
               player.GetComponent<PlayerController>().enabled = false;
        }
        else if (sceneName == Constants.TOWN_SCENE_NAME)
        {
            if (player != null)
                player.GetComponent<PlayerController>().enabled = true;
        }
        else if (sceneName == Constants.HOME_SCENE_NAME)
        {
            if (player != null)
                player.GetComponent<PlayerController>().enabled = true;
        }
        else if (sceneName == Constants.DUNGEON_SCENE_NAME)
        {
            if (player != null)
                player.GetComponent<PlayerController>().enabled = false;
        }

    }

    public void setOrder(int newOrder)
    {
        playerStats.playerData.plotOrder = newOrder;
        //Debug.Log("save order");    
    }

    IEnumerator SaveBeforeLoad(string newSceneName)
    {
        DataManager.Instance.Save();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(newSceneName);
    }

    #endregion

    #region Log
    public static void AppendLog(string message)
    {
        var logPath = Path.Combine(Application.dataPath, "Debug.log");
        using (StreamWriter writer = new StreamWriter(logPath, true))
        {
            writer.WriteLine(message);
        }
    }
    #endregion



}
