using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Faded.Atlas
{
    public class PlaceAvatarBase : MonoBehaviour
    {
        public bool isAround = false;
        private bool isEntering = false;
        [SerializeField] private PlaceAvatarType type;

        [Header("Details for Avatar")]
        [SerializeField] protected TextMeshProUGUI hints;

        private void OnEnable()
        {
            isAround = false;
            isEntering = false;
        }

        private void OnDisable()
        {
            isAround = false;
            isEntering = false;
        }

        private void Update()
        {
            if(isAround && !isEntering && Input.GetKeyDown(KeyCode.Return))
            {
                OnEnter();
                isEntering = true;
            }

        }

        protected virtual void OnEnter()
        {
#if UNITY_EDITOR
            Debug.Log("Enter " + type.ToString());
    #endif
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
                isAround = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                isAround = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                isAround = true;
        }

    }
}
