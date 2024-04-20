using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void OnNewGame()
    {
        GameManager.Instance.StartNewGame();
    }

    public void OnContinue()
    {
        GameManager.Instance.ContinueGame();
    }

    public void OnOptions()
    {
#if UNITY_EDITOR
        Debug.Log("Options here");
#endif
    }

    public void OnCredit()
    {
#if UNITY_EDITOR
        Debug.Log("Credit here");
#endif
    }

    public void OnExit()
    {
        GameManager.Instance.ExitGame();
    }


}
