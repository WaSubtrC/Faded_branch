using UnityEngine;
using UnityEngine.SceneManagement;

namespace Faded.Town
{
    public class MerchantInteractable : MonoBehaviour, IInteractable
    {
        //public InventoryData_SO storeData;
        [SerializeField] private string interactText;
        [SerializeField] private string talkText;
        [SerializeField] private GameObject _storeUI;

        [SerializeField] private PlayerInteract playerInteract;

        private void Start()
        {
            if (_storeUI == null) Debug.Log("Shopwindow not found");
            playerInteract = GameManager.Instance.player.GetComponentInChildren<PlayerInteract>();
        }

        #region IInteractable
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

        public void OnInteract()
        {
            if (!_storeUI.activeInHierarchy)
            {
                _storeUI.SetActive(true);
            }
            else { Hide(); }
        }
        #endregion

        private void Update()
        {
            if (playerInteract.GetInteractableObject() == null)
            {
                Hide();
                //Show(playerInteract.GetInteractableObject());
            }
        }

        #region UI_FarAutoHide
        private void Hide()
        {
            if (_storeUI == null) return;
            _storeUI.SetActive(false);
        }

   
        //private void Show(IInteractable interactable)
        //{
        //    self.SetActive(true);
        //}

        #endregion
    }

}
