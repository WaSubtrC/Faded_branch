using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Faded.Town
{
    public class FlashlightController : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Secret"))
            {
                other.GetComponent<SecretContainer>()?.OnReveal();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Secret"))
            {
                other.GetComponent<SecretContainer>()?.OnHide();
            }
        }

    }
}

