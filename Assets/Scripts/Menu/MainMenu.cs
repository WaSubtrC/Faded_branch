using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void OnNewGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start new game");
    }

    public void OnContinue()
    {

        try { 
            SaveManager.Instance.Load();
            Debug.Log("load");
        }
        catch
        {
            Debug.LogError("Fail to load game");
            return;
        }
        SceneManager.LoadScene(1);
    }

    public void OnOptions()
    {
        Debug.Log("Options here");
    }

    public void OnCredit()
    {
        Debug.Log("Credit here");
    }

    public void OnExit()
    {
        Application.Quit();
        Debug.Log("Exit game");
    }


}
