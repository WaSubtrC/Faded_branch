using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] private GameObject menu;

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
        Debug.Log("save game");
        SaveManager.Instance.Save();

    }

    public void OnOptions()
    {
        Debug.Log("options here");
    }


    public void OnReturnToMainMenu()
    {
        SaveManager.Instance.Save();
        SceneManager.LoadSceneAsync("Menu");
    }

}
