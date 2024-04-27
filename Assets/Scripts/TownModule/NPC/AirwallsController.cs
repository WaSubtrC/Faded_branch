using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Fungus;

public class AirwallsController : MonoBehaviour
{
    [SerializeField] protected GameObject airwall;
    [SerializeField] protected int border;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    IEnumerator SetUpAirwall()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.Instance.playerStats.playerData.plotOrder >= border)
            airwall.SetActive(false);
        else
            airwall.SetActive(true);
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(SetUpAirwall());
    }
}
