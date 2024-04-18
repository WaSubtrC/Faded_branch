using UnityEngine;

public class MerchantInteractable : MonoBehaviour, IInteractable
{
    //public InventoryData_SO storeData;
    [SerializeField] private string interactText;
    [SerializeField] private string talkText;
    [SerializeField] private GameObject _storeUI;

    [SerializeField] private PlayerInteract playerInteract;

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
    //if null active /!=null false
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
        _storeUI.SetActive(false);
    }
    //private void Show(IInteractable interactable)
    //{
    //    self.SetActive(true);
    //}

    #endregion
}
