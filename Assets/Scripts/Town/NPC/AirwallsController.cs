using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Fungus;

public class AirwallsController : MonoBehaviour
{
    [SerializeField] protected GameObject airwall;
    [SerializeField] protected int plot;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    IEnumerator OnUpdateAirwall()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.Instance.playerStats.playerData.plotOrder >= plot)
            airwall.SetActive(false);
        else
            airwall.SetActive(true);
        
    }

    public void UpdateAirwall()
    {
        StartCoroutine(OnUpdateAirwall());
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateAirwall();
    }



}
