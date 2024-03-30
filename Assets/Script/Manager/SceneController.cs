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
        
        //保存玩家数据
        SavaManager.Instance.SavePlayerData();
        yield break;
    }


    IEnumerator LoadMainMenu()//返回主菜单
    {
        yield return SceneManager.LoadSceneAsync("Menu");
        yield break;
    }
}
