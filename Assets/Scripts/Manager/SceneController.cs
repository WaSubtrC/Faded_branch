using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{

    public void TransitionToFirstLevel()
    {
        StartCoroutine(LoadScene("Town"));
    }
    public void TransitionToLoadGame()
    {
        StartCoroutine(LoadScene(SaveManager.Instance.SceneName));
    }

    public void TransitionToMainMenu()
    {
        StartCoroutine(LoadScene("Menu"));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        
        yield return SceneManager.LoadSceneAsync(sceneName);
        
        SaveManager.Instance.SavePlayerData();
        yield break;
    }


}
