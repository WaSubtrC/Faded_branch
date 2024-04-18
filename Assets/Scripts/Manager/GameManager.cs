using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerStatus playerStats;
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

    }
    
    public void RegisterPlayer(PlayerStatus player)
    {
        playerStats = player;
    }






}
