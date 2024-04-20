using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Faded.Town
{
    public class Task2 : MonoBehaviour
    {
        public bool isDone = false;

        [Tooltip("玩家距离这里的最大距离")]
        public float radius;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Transform playerTransform = GameObject.FindWithTag("Player").transform;
                if (Vector3.Distance(playerTransform.position, transform.position) <= radius)
                {
                    Trigger();
                }
            }
        }

        public void Trigger()
        {
            if (isDone) return;
            isDone = true;
            //TODO:获得装备
            Debug.Log("获得装备");
            Destroy(gameObject);
        }
    }
}

