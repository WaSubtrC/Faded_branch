using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MissionGoods
{
    public InventoryItem inventoryItem;
}
[System.Serializable]
public struct MissionData
{
    [Header("任务描述")]
    public string des;
    [Header("任务的ID")]
    public int id;
    [Header("任务需要达成的条件")]
    public ItemData_SO needGoods;
    [Header("任务完成的奖励")]
    public ItemData_SO rewardGoods;
}
[CreateAssetMenu(fileName = "New MissionDatabase",menuName ="Create New MissionDatabase/New Mission Database")]
public class MissionDatabase : ScriptableObject {

    public List<MissionData> missionTasks;
}
