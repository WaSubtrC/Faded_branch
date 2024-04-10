using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Task1 : MonoBehaviour
{
    private Transform ThePurpleTransform;
    public Transform[] waypoints;
    public int index = 0;
    public float threshold;
    public float speed;

    private NavMeshAgent navMeshAgent;



    private void Start()
    {
        ThePurpleTransform = GameObject.Find("The Purple").GetComponent<Transform>();
        for(int i=0;i<waypoints.Length;i++)waypoints[i].gameObject.SetActive(false);

         navMeshAgent = GameObject.Find("The Purple").GetComponent<NavMeshAgent>();
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;


    }
    private void Update()
    {
        navMeshAgent.speed = speed;

        //MoveTo();
        MoveToPos();
    }
    #region Move Function
    private void MoveToPos()
    {
        if (index == waypoints.Length)
            return;

        var target = waypoints[index];
        var dir = (target.position - ThePurpleTransform.position).normalized;

        // 使用NavMeshAgent进行移动
        //navMeshAgent.Move(speed * Time.deltaTime * dir);
        navMeshAgent.SetDestination(target.position);
        
        
        // 如果距离小于等于指定的阈值，则增加索引以移动到下一个路径点
        var dis = Dis(target.position, ThePurpleTransform.position);

        if (dis <= threshold)
        {
            index++;
        }
    }
    float Dis(Vector3 a, Vector3 b)
    {
        var delta = a - b;
        return Mathf.Sqrt(delta.x * delta.x + delta.z * delta.z);
    }
    #endregion

    
}


    //private void MoveTo()
    //{
    //    if (index == waypoints.Length) return;
    //    var target = waypoints[index];
    //    var dir = (target.position - ThePurpleTransform.position).normalized;

    //    ThePurpleTransform.Translate(speed * Time.deltaTime * dir);
    //    var dis = Dis(target.position, ThePurpleTransform.position);
    //    //Debug.Log(dis);
    //    if (dis <= threshold)
    //    {
    //        index++;
    //    }
    //}


