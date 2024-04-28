using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Fungus;

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


        AppendLog("Start game at" + DateTime.Now.ToString());
    }

    #region Atlas
    public void OnEnterTown()
    {
        SceneManager.LoadScene(Constants.TOWN_SCENE_NAME);

        player.GetComponent<PlayerController>().OnMoveToward(new Vector3(-78f, 9.5f, 34f));
        player.GetComponentInChildren<MainCamera>().OnTowardOutside();

        AudioManager.Instance.Switch("Town");

    }

    public void OnEnterHome()
    {
        SceneManager.LoadScene(Constants.HOME_SCENE_NAME);

        player.GetComponent<PlayerController>().OnMoveToward(new Vector3(-1f, 1.5f, -2f));
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
        SceneManager.LoadScene(Constants.DUNGEON_SCENE_NAME);
        AudioManager.Instance.Switch("Dungeon");
    }

    #endregion

    #region Init
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (playerStats != null)
            StartCoroutine(SaveBeforeLoad());

        string sceneName = scene.name;
        if (sceneName == Constants.MENU_SCENE_NAME)
        {

        }
        else if (sceneName == Constants.TOWN_SCENE_NAME)
        {
            if (player == null)
                player = GameObject.FindWithTag("Player");
            if (playerStats == null && player != null)
                playerStats = player.GetComponent<PlayerStatus>();
        }
        else if (sceneName == Constants.HOME_SCENE_NAME)
        {

        } else if (sceneName == Constants.DUNGEON_SCENE_NAME)
        {

        }

    }

    public void setOrder(int newOrder){
        playerStats.playerData.plotOrder = newOrder;
        //Debug.Log("save order");    
    }

    IEnumerator SaveBeforeLoad()
    {
        yield return new WaitForSeconds(0.5f);
        DataManager.Instance.Save();
    }

    #endregion


    #region Menu
    public void StartNewGame()
    {
        SceneManager.LoadScene(Constants.TOWN_SCENE_NAME);
        StartCoroutine(OnStartNewGame());

#if UNITY_EDITOR
        Debug.Log("Start new game");
#endif
    }

    IEnumerator OnStartNewGame()
    {
        yield return new WaitForSeconds(0.2f);

        //init player pos


        Instance.player.GetComponentInChildren<MainCamera>().OnStartNewGame();
        Instance.player.GetComponent<PlayerController>().OnMoveToward(new Vector3(-39f, 22.5f, 86f));

        UIManager.Instance.gameObject.SetActive(true);
        UIManager.Instance.SetUp();

        AtlasManager.Instance.OnTransPlace();

        AudioManager.Instance.Switch("Town");

    }

    public void ContinueGame()
    {
        try
        {
            DataManager.Instance.Load();
        }
        catch
        {
            AppendLog("fail to load data");
            return;
        }
        SceneManager.LoadScene(Constants.TOWN_SCENE_NAME);

        UIManager.Instance.gameObject.SetActive(true);
        UIManager.Instance.SetUp();

        AtlasManager.Instance.OnTransPlace();

        AudioManager.Instance.Switch("Town");
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        Debug.Log("Exit game");
#endif
        AppendLog("Start game at" + DateTime.Now.ToString());
    }
    #endregion


    #region Log
    public static void AppendLog(string message)
    {
        var logPath = Path.Combine(Application.dataPath, "debug.log");
        using (StreamWriter writer = new StreamWriter(logPath, true))
        {
            writer.WriteLine(message);
        }
    }
    #endregion






}
