using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public CharacterStats playerStats;

    public void RigisterPlayer(CharacterStats player)
    {
      playerStats =player   ;
    }





}
