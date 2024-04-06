using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    private Transform ThePurpleTransform;
    public Transform[] waypoints;
    public int index = 0;
    public float threshold;
    public float speed;

    private void Start()
    {
        ThePurpleTransform = GameObject.Find("The Purple").GetComponent<Transform>();
        for(int i=0;i<waypoints.Length;i++)waypoints[i].gameObject.SetActive(false);
    }


    float Dis(Vector3 a, Vector3 b)
    {
        var delta = a - b;
        return Mathf.Sqrt(delta.x * delta.x + delta.z * delta.z);
    }
    private void Update()
    {
        if(index==waypoints.Length)return;
        var target = waypoints[index];
        var dir = (target.position - ThePurpleTransform.position).normalized;
        ThePurpleTransform.Translate( speed * Time.deltaTime * dir);
        var dis = Dis(target.position, ThePurpleTransform.position);
        //Debug.Log(dis);
        if ( dis<= threshold)
        {
            index++;
        }
    }
    
    
}
