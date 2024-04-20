using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using FadedTown;

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
    }

    public void OnEnterHome()
    {
        SceneManager.LoadScene(Constants.HOME_SCENE_NAME);
    }



/* TODO:
 *  1. Save data(player's position in town, playerAvatar's position on atlas)
 *  2. Load dungeon scene (init by layer¡¢level£¬level decides the basic stats of monster, this can be implemented later)
 *  3. Inherit data from PlayerStatus to Player
*/
    public void OnEnterDungeon()
    {
        SceneManager.LoadScene(Constants.DUNGEON_SCENE_NAME);
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
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            playerStats = player.GetComponent<PlayerStatus>();
    }
    #endregion


    #region Menu
    public void StartNewGame()
    {
        SceneManager.LoadScene(Constants.TOWN_SCENE_NAME);
        UIManager.Instance.gameObject.SetActive(true);
        UIManager.Instance.SetUp();
#if UNITY_EDITOR
        Debug.Log("Start new game");
#endif
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
        SceneManager.LoadScene(1);
        UIManager.Instance.gameObject.SetActive(true);
        UIManager.Instance.SetUp();
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
