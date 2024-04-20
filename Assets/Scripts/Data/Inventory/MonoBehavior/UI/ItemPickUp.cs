using UnityEngine;

namespace Faded.Town {
    public class ItemPickUp : MonoBehaviour,IInteractable 
    {
        public ItemData_SO itemData;
        [SerializeField]private string interactText="Pick up the Item";


        #region IInteractable
        public string GetInteractText()
        {
            return interactText;
        }

        public Transform GetTransform()
        {
            return transform;
        }
        public void Interact()
        {
   
            InventoryManager.Instance.inventoryData.AddItem(itemData, itemData.itemAmount);
            InventoryManager.Instance.inventoryUI.RefreshUI();

            TaskManager.Instance.PickUpItem(this);
            Destroy(gameObject);
        }

        #endregion





    }
}
