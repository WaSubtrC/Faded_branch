using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Faded.Town
{
    public class ChestInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string interactText;
        [SerializeField] private GameObject ChestPrefabUI;
        [SerializeField] private InventoryData_SO chestData;
        private GameObject chestUI;
        private PlayerInteract playerInteract;

        private void Start()
        {
            playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        }
        private void Update()
        {
            if (playerInteract.GetInteractableObject() == null)
            {
                Destroy(chestUI);
            }
        }

        #region IInteractable Interface
        public string GetInteractText()
        {
            return interactText;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void OnInteract()
        {
            if(chestUI == null)
            {
                chestUI =  Instantiate(ChestPrefabUI,GameObject.Find("InventoryCanvas").transform);
                UIManager.Instance.ShowBackpack();
                chestUI.GetComponent<RectTransform>().SetSiblingIndex(1);
                InventoryManager.Instance.SetChestData(chestData);

            }
            else
            {
                Destroy(chestUI);
                UIManager.Instance.HideBackpack();
            }

        }

        public KeyCode GetKeyCode()
        {
            return KeyCode.O;
        }

        #endregion
    }
}
