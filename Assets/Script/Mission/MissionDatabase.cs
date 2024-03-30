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
    [Header("��������")]
    public string des;
    [Header("�����ID")]
    public int id;
    [Header("������Ҫ��ɵ�����")]
    public ItemData_SO needGoods;
    [Header("������ɵĽ���")]
    public ItemData_SO rewardGoods;
}
[CreateAssetMenu(fileName = "New MissionDatabase",menuName ="Create New MissionDatabase/New Mission Database")]
public class MissionDatabase : ScriptableObject {

    public List<MissionData> missionTasks;
}
