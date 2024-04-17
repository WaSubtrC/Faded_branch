using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskItem: MonoBehaviour
{
    public TextMeshProUGUI taskText;
    public TaskItemData_SO data;
    public bool isDone;

    public void SetData(TaskItemData_SO data)
    {
        this.data = data;
        taskText.text = data.text;
    }
    
    public void Done()
    {
        TaskManager.Instance.RemoveTask(this);
        for (int i = 0; i < data.nextTasks.Count; i++)
        {
            TaskManager.Instance.AddTask(data.nextTasks[i]);
        }
        if(data.taskId == 2)Task2();
        if (data.taskId == 1) Task1();
        Destroy(gameObject);
    }

    void Task2()
    {
        GameObject.Find("Task2").GetComponent<Task2>().enabled = true;
    }

    void Task1()
    {
        GameObject.Find("Task1").GetComponent<Task1>().enabled = true;
    }
}
