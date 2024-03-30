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
        //ת����������ȡ����
        try { 
        SavaManager.Instance.Load();
        SceneManager.LoadScene(1);
        }
        catch
        {
            Debug.LogError("���ȶ�ȡʧ��");
        }
    }
    public  void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
