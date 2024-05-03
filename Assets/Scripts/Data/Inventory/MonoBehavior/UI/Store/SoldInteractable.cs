using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faded.Town
{
    public class SoldInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _interactText;
        [SerializeField] private GameObject SoldUI_Prefab;
        [SerializeField] private InventoryData_SO SoldData;

        private GameObject _soldUI;
        private PlayerInteract playerInteract;

        public string GetInteractText()
        {
            return _interactText;
        }

        public KeyCode GetKeyCode()
        {
            return KeyCode.E;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void OnInteract()
        {
            if (_soldUI == null)
            {
                _soldUI = Instantiate(SoldUI_Prefab, GameObject.Find("InventoryCanvas/ChestBar").transform);
                _soldUI.GetComponent<Transform>().SetSiblingIndex(1);
                UIManager.Instance.ShowBackpack();

                InventoryManager.Instance.SetSoldData(SoldData);
                InventoryManager.Instance.isSelling = true;

            }
            else
            {

                Destroy(_soldUI);

                UIManager.Instance.HideBackpack();
                InventoryManager.Instance.isSelling = false;

            }
        }
    }
}
