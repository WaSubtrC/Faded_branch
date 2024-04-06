using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType
{
    PICKUP,
    TALKWITH,
    NONE
}

[CreateAssetMenu(menuName = "TaskItemData",order = 0,fileName = "task")]
public class TaskItemData_SO : ScriptableObject
{
    public int taskId;
    public string text;
    public List<TaskItemData_SO> nextTasks;     //任务完成之后新添加的任务
    public TaskType taskType;
    public ItemData_SO pickItem;
    public string talkName;         //谈话的人的名字
}
