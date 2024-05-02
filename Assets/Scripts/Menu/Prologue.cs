using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Fungus;

public class Prologue : MonoBehaviour
{
    public Image imageToFade; 
    public float fadeDuration = 5.0f;

    public Flowchart flowchart;

    [SerializeField] private string startChatName;
    [SerializeField] private string tip1ChatName;

    private void Awake()
    {
        imageToFade = GetComponent<Image>();
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    private void Start()
    {
        StartCoroutine(startGame());
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(2f);
        flowchart.ExecuteBlock(startChatName);
    }

    public void StartFading()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0;
        Color originalColor = imageToFade.color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeDuration);
            imageToFade.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageToFade.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        yield return new WaitForSeconds(1f);
        flowchart.ExecuteBlock(tip1ChatName);
        gameObject.SetActive(false);
        
    }
}