using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Faded.Town {

    [RequireComponent(typeof(Collider))]
    public class SecretContainer : MonoBehaviour
    {
        private GameObject target;

        private void Awake()
        {
            if (target == null)
            {
                target = transform.GetChild(0).gameObject;
#if UNITY_EDITOR
                if (target == null)
                    Debug.Log("Secret target no found");
#endif
            }
            OnHide();

        }

        public void OnReveal()
        {
            target.SetActive(true);
            Debug.Log("reveal");
        }

        public void OnHide()
        {
            target.SetActive(false);
        }

    }
}


