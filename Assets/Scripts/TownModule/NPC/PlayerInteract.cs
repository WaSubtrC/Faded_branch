using System.Collections.Generic;
using UnityEngine;


namespace Faded.Town 
{
    public class PlayerInteract : MonoBehaviour
    {

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractable interactable = GetInteractableObject();
                if (interactable != null)
                {
                    interactable.OnInteract();
                }
            }
        }

        public IInteractable GetInteractableObject()
        {
            List<IInteractable> InteractableList = new List<IInteractable>();
            float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {   //遍历collider 试图获取 挂载npc脚本的collider其中的脚本

                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    InteractableList.Add(interactable);
                }
            }

            //搜寻最近的NPC脚本transform
            IInteractable closestNPCInteractable = null;
            foreach (IInteractable interactable in InteractableList)
            {
                if (closestNPCInteractable == null)
                {
                    closestNPCInteractable = interactable;
                }
                else
                {
                    if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                        Vector3.Distance(transform.position, closestNPCInteractable.GetTransform().position))
                    {   //closer
                        closestNPCInteractable = interactable;
                    }
                }
            }
            return closestNPCInteractable;

        }
    }
}


