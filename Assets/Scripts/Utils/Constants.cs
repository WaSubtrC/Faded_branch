using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class Constants
{
    //Scene 
    public static string MENU_SCENE_NAME = "MenuScene";
    public static string TOWN_SCENE_NAME = "TownScene";
    public static string HOME_SCENE_NAME = "HomeScene";
    public static string DUNGEON_SCENE_NAME = "DungeonScene";

    //NPC
    public static string NPC_OBJ_NAME_THE_PURPLE = "The Purple";

    //Point
    public static Vector3 POINT_TOWN_BORN = new Vector3(-39f, 22.5f, 86f);
    public static Vector3 POINT_TOWN_ENTER = new Vector3(-76f, 9.5f, 34f);
    public static Vector3 POINT_HOME_ENTER = new Vector3(-1f, 1.5f, -2f);
}

enum PlaceAvatarType
{
    DUNGEON, TOWN, HOME
}