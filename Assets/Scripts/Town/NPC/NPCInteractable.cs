using Fungus;
using System.Collections;
using UnityEngine;


namespace Faded.Town
{
    public class NPCInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string interactText;
        [SerializeField] private string chatName_01;

        protected Flowchart flowchart;

        public virtual void OnInteract()
        {
            Say();
        }


        public string GetInteractText()
        {
            return interactText;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public KeyCode GetKeyCode()
        {
            return KeyCode.E;
        }
        private void Say()
        {
            flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            if (flowchart.HasBlock(chatName_01))
            {
                flowchart.ExecuteBlock(chatName_01);
            }
            else 
            { 
                Debug.LogWarning(chatName_01 + "can not found;"); 
            }

        }
    }

}
