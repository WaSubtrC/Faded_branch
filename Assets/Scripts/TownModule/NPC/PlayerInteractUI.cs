using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        if (playerInteract == null) return;
        if(playerInteract.GetInteractableObject() != null)
        {
            Show(playerInteract.GetInteractableObject());
        }else { 
            Hide(); 
        }
    }

    private void Show(IInteractable interactable)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText(); //������ʾ�ı�==NPC�ض������ı�
    }
    private void Hide()
    {
        containerGameObject.SetActive(false);
    }

    void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (playerInteract == null)
        {
            playerInteract = GameObject.FindWithTag("Player")?.GetComponent<PlayerInteract>();
        }
    }
}
