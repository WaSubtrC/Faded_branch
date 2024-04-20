using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] public GameObject menu;

    private void Start()
    {
        menu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            menu.SetActive(!menu.activeSelf);
        }
    }

    public void OnContinue()
    {
        menu.SetActive(false);
    }

    public void OnSave()
    {
        DataManager.Instance.Save();
    }

    public void OnOptions()
    {
#if UNITY_EDITOR
        Debug.Log("Options here");
#endif
    }


    public void OnReturnToMainMenu()
    {
        DataManager.Instance.Save();
        UIManager.Instance.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync("Menu");
    }

}
