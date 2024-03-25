using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : MonoBehaviour
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
        if (playerInteract.GetInteractableObject() != null)
        {
            //Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteractable interactable)
    {
        self.SetActive(true);
    }
    private void Hide()
    {
        self.SetActive(false);
    }
}
