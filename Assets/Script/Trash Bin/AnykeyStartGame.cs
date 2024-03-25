using UnityEngine;
using UnityEngine.SceneManagement;

public class AnykeyStartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
    }
}
