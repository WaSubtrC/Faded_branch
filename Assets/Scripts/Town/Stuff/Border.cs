using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faded.Town{
    public class Border : MonoBehaviour
    {

        [SerializeField] GameObject Atlas;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AtlasManager.Instance.atlas.SetActive(true);
                AtlasManager.Instance.OnTransAtlas();

            }

        }
    }
}

