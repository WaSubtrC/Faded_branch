using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactable = GetInteractableObject();
            if(interactable != null)
            {
                interactable.Interact();
            }
        }
    }

        public IInteractable GetInteractableObject()
        {
            List<IInteractable> InteractableList = new List<IInteractable>();
            float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {   //����collider ��ͼ��ȡ ����npc�ű���collider���еĽű�
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    InteractableList.Add(interactable);
                }
            }
            //��List��Ѱ�����NPC�ű�transform
            IInteractable closestNPCInteractable = null;
        foreach(IInteractable interactable in InteractableList)
        {
            if(closestNPCInteractable == null)
            {
                closestNPCInteractable = interactable;
            }
            else
            {
                if(Vector3.Distance(transform.position,interactable.GetTransform().position) <
                    Vector3.Distance(transform.position,closestNPCInteractable.GetTransform().position) )
                {   //closer
                    closestNPCInteractable = interactable;
                }
            }
        }
            return closestNPCInteractable;
            
        }
}
