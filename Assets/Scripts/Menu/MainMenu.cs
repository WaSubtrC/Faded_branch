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
            SceneManager.LoadScene(1);
        }
        catch
        {
            Debug.LogError("Fail to load game");
        }
    }

    public void OnOptions()
    {
        Debug.Log("Options here");
    }

    public void OnCredit()
    {
        Debug.Log("Options here");
    }

    public void OnExit()
    {
        Application.Quit();
        Debug.Log("Exit game");
    }


}
