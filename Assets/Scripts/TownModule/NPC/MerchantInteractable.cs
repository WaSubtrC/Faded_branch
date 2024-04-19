using UnityEngine;
using UnityEngine.SceneManagement;

public class MerchantInteractable : MonoBehaviour, IInteractable
{
    //public InventoryData_SO storeData;
    [SerializeField] private string interactText;
    [SerializeField] private string talkText;
    [SerializeField] private GameObject _storeUI;

    [SerializeField] private PlayerInteract playerInteract;

    private void Start()
    {
        _storeUI = GameObject.Find("UI/InventoryCanvas/ShopWindow");
        if (_storeUI == null) Debug.Log("Shopwindow not found");
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

    public void Interact()
    {
        if(!_storeUI.activeInHierarchy) {       
            _storeUI.SetActive(true);
        }else { Hide(); }
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
