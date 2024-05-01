using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Fungus;

namespace Faded.Town
{
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
            ThePurpleTransform = GameObject.Find(Constants.NPC_OBJ_NAME_THE_PURPLE).GetComponent<Transform>();
            for (int i = 0; i < waypoints.Length; i++) waypoints[i].gameObject.SetActive(false);

            navMeshAgent = GameObject.Find(Constants.NPC_OBJ_NAME_THE_PURPLE).GetComponent<NavMeshAgent>();
            navMeshAgent.updateUpAxis = false;
            navMeshAgent.updateRotation = false;
            navMeshAgent.speed = speed;
        }

        private void Update()
        {

            MoveToPos();
        }


        #region Move Function
        private void MoveToPos()
        {
            if (index == waypoints.Length)
            {
                GameObject.Find("Flowchart").GetComponent<Flowchart>().SetBooleanVariable("endNavigation", true);
                return;
            }


            var target = waypoints[index];
            var dir = (target.position - ThePurpleTransform.position).normalized;

            navMeshAgent.SetDestination(target.position);
            var dis = Vector3.Distance(target.position, ThePurpleTransform.position);
            //Move to next point
            if (dis <= threshold)
            {
                index++;
            }
        }
        #endregion


    }
}




