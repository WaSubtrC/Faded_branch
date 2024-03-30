using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{

    public void TransitionToFirstLevel()
    {
        StartCoroutine(LoadLevel("Town"));
    }
    public void TransitionToLoadGame()
    {
        StartCoroutine(LoadLevel(SavaManager.Instance.SceneName));
    }

    public void TranstionToMain()
    {
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadLevel(string sceneName)
    {
        
        yield return SceneManager.LoadSceneAsync(sceneName);
        
        //�����������
        SavaManager.Instance.SavePlayerData();
        yield break;
    }


    IEnumerator LoadMainMenu()//�������˵�
    {
        yield return SceneManager.LoadSceneAsync("Menu");
        yield break;
    }
}
