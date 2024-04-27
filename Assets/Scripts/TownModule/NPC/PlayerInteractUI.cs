using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Faded.Town 
{
    public class PlayerInteractUI : MonoBehaviour
    {
        [SerializeField] private GameObject containerGameObject;
        [SerializeField] private PlayerInteract playerInteract;
        [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
        [SerializeField] private TMP_Text pressKeyText;


        private void Start()
        {
            pressKeyText = GameObject.Find("InteractKey").GetComponent<TMP_Text>();
        }
        private void Update()
        {
            if (playerInteract == null) return;
            if (playerInteract.GetInteractableObject() != null)
            {
                Show(playerInteract.GetInteractableObject());
            }
            else
            {
                Hide();
            }
        }

        private void Show(IInteractable interactable)
        {
            containerGameObject.SetActive(true);
            interactTextMeshProUGUI.text = interactable.GetInteractText(); //互动提示文本==NPC特定互动文本
            pressKeyText.SetText(interactable.GetKeyCode().ToString()); //互动按键文本==NPC特定互动按键
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
}


