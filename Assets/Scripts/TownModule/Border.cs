using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Border : MonoBehaviour
{

    [SerializeField] GameObject Atlas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Atlas.SetActive(true);
            AtlasManager.Instance.OnTransAtlas();

        }

    }
}
