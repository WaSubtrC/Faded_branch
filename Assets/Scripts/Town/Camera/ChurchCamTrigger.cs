using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faded.Town {
    public class CameraCamTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponentInChildren<MainCamera>().OnTowardInChurch();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponentInChildren<MainCamera>().OnTowardOutChurch();
            }
        }

    }

}



