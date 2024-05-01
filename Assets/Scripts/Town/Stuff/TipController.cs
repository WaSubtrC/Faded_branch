using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fungus;

namespace Faded.Town
{
    public class TipController : MonoBehaviour
    {
        [SerializeField] private string chatName;
        protected Flowchart flowchart;

        public void OnTip()
        {

            flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            if (flowchart.HasBlock(chatName))
            {
                Debug.Log("tip");
                flowchart.ExecuteBlock(chatName);
            }
            else
            {
                Debug.LogWarning(chatName + " can not found;");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnTip();
            }
        }

    }

}


