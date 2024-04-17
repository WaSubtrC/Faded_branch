using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public CharacterStats playerStats;
    [Header("Prefab")]
    public Transform pfChatBubble;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    //public void RigisterPlayer(CharacterStats player)
    //{
    //    playerStats = player;
    //}






}
