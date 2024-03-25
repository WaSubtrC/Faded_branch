using UnityEngine;
using System.Collections.Generic;

public class GameObjectDetection : MonoBehaviour
{
    public float detectionRadius = 2f;
    public LayerMask detectionLayer; 

    void Update()
    {
        // 检测给定位置周围的特定层的碰撞器
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);
        
        // 检测到碰撞器
        if (colliders.Length == 0)
        {
                GameObject.Find("UI_Manager").SendMessage("ItemTIPS_Controller", false);

        }
        else    //有layer类的GameObject
        {
                GameObject.Find("UI_Manager").SendMessage("ItemTIPS_Controller", true);
                //不写的另一种方案:if（input.key.F）销毁gameobject

        }
        //Debug.Log(colliders.Length);
    }
}
