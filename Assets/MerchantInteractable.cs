using UnityEngine;

public class MerchantInteractable : MonoBehaviour, IInteractable
{
    //public InventoryData_SO storeData;
    [SerializeField] private string interactText;
    [SerializeField] private string talkText;
    [SerializeField]private GameObject _storeUI;
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
        if(!_storeUI.activeInHierarchy) 
        {
            _storeUI.SetActive(true);
        }else { _storeUI.SetActive(false);}
    }
}
