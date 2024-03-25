using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static void StartGame()
    {
        SceneManager.LoadScene(1);
        //Debug.Log("Start");
    }
    public static void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
