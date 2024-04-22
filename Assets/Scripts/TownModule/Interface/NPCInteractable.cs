using Fungus;
using System.Collections;
using UnityEngine;


namespace Faded.Town
{
    public class NPCInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] protected string interactText;
        [SerializeField] protected string chatName_01;
        protected Flowchart flowchart;

        public virtual void OnInteract()
        {
            OnChat();
            //ChatBubble.Create(transform.transform, new Vector3(-3,0,0), ChatBubble.IconType.Happy, "test");
        }


        public string GetInteractText()
        {
            return interactText;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        protected virtual void OnChat()
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
