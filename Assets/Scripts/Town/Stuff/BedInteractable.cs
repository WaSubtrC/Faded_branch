using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Faded.Town
{
    public class BedInteractable : MonoBehaviour, IInteractable
    {

        private PlayerInteract playerInteract;

        [Header("UI")]
        [SerializeField] private string interactText;
        [SerializeField] private GameObject bedPrefabUI;


        private void Start()
        {
            playerInteract = GameManager.Instance.player.GetComponent<PlayerInteract>();
        }

        private void Update()
        {

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
            AtlasManager.Instance.OnTransitionAnim();
            float maxH = GameManager.Instance.playerStats.playerData.maxHealth;
            GameManager.Instance.playerStats.playerData.currHealth = maxH;
        }

        public KeyCode GetKeyCode()
        {
            return KeyCode.E;
        }

        #endregion
    }
}
