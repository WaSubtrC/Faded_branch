using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    public GameObject TaskMenuContent;
    public GameObject TaskMenu;
    public List<TaskItem> taskItems;
    public TaskItem taskItemPrefab;
    public List<TaskItemData_SO> initialDatas;
    public void OpenTaskMenu()
    {
        TaskMenu.SetActive(true);
    }

    private void Start()
    {
        for(int i=0;i<initialDatas.Count;i++)AddTask(initialDatas[i]);
    }
    private void Update()
    {
        for(int i=0;i<taskItems.Count;i++)
            if (taskItems[i].isDone)
            {
                taskItems[i].Done();
                break;
            }
    }

    public void CloseTaskMenu()
    {
        TaskMenu.SetActive(false);
    }

    public void RemoveTask(TaskItem item)
    {
        for (int i = 0; i < taskItems.Count; i++)
        {
            if (taskItems[i] == item)
            {
                taskItems.RemoveAt(i);
                break;
            }
        }
    }
    public void AddTask(TaskItemData_SO item)
    {
        var obj = Instantiate<TaskItem>(taskItemPrefab,TaskMenuContent.transform);
        taskItems.Add(obj);
        obj.SetData(item);
    }

    public void PickUpItem(ItemPickUp pickUp)
    {
        for (int i = 0; i < taskItems.Count; i++)
        {
            if (taskItems[i].data.taskType == TaskType.PICKUP && taskItems[i].data.pickItem == pickUp.itemData)
            {
                taskItems[i].isDone = true;
            }
        }
    }

    public void TalkWith(NPCInteractable npcInteractable)
    {
        foreach (var taskItem in taskItems)
        {

            if (taskItem.data.taskType == TaskType.TALKWITH && taskItem.data.talkName == npcInteractable.gameObject.name)
            {
                    taskItem.isDone = true;
            }
        }
    }

}
