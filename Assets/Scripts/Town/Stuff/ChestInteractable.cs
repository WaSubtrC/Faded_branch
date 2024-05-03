using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Faded.Town
{
    public class ChestInteractable : MonoBehaviour, IInteractable
    {

        private PlayerInteract playerInteract;

        [Header("UI")]
        private GameObject chestUI;
        [SerializeField] private string interactText;
        [SerializeField] private GameObject ChestPrefabUI;

        [Header("Data")]
        [SerializeField] private string key; //use to identify json file
        [SerializeField] private InventoryData_SO chestData;

        [Header("Animation")]
        private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite closeSprite;
        [SerializeField] private Sprite openSprite;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = closeSprite;
        }

        private void Start()
        {
            playerInteract = GameManager.Instance.player.GetComponent<PlayerInteract>();
            chestData = DataManager.Instance.getChestData(key);
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
            if (chestUI == null)
            {
                chestUI =  Instantiate(ChestPrefabUI,GameObject.Find("InventoryCanvas/ChestBar").transform);
                chestUI.GetComponent<RectTransform>().SetSiblingIndex(1);

                InventoryManager.Instance.SetChestData(chestData); 
                   
                UIManager.Instance.ShowBackpack();
                spriteRenderer.sprite = openSprite;

            }
            else
            {
                Destroy(chestUI);
                
                UIManager.Instance.HideBackpack();
                spriteRenderer.sprite = closeSprite;
            }

        }

        public KeyCode GetKeyCode()
        {
            return KeyCode.O;
        }

        #endregion
    }
}
