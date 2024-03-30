using UnityEngine;

public class UI_FarAutoHide : MonoBehaviour
{
    private GameObject self;
    [SerializeField] private PlayerInteract playerInteract;

  void Start()
    {
        self = this.gameObject;
        //playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
    }

    private void Update()
    {
        if (playerInteract.GetInteractableObject() == null)
        {
            Hide();
            //Show(playerInteract.GetInteractableObject());
        }
        
    }
    //private void Show(IInteractable interactable)
    //{
    //    self.SetActive(true);
    //}
    private void Hide()
    {
        self.SetActive(false);
    }
}
