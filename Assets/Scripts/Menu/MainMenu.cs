using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public  void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start");
    }

    public void ContinueGame()
    {
        //转换场景，读取进度
        try { 
        SavaManager.Instance.Load();
        SceneManager.LoadScene(1);
        }
        catch
        {
            Debug.LogError("进度读取失败");
        }
    }
    public  void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
