using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionController : MonoBehaviour
{


    private Material material;

    [SerializeField] private Image TransisitonImage;
    [SerializeField] private GameObject newImage;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float duration = 1f;


    void Start()
    {
        material = TransisitonImage.material;
        material.SetFloat("_Life", 0);
    }


    void Update()
    {
        // test
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(OnTransition());
        }
    }

    IEnumerator OnTransition()
    {
        float timer = 0;
        while(timer <= duration)
        {
            material.SetFloat("_Life", curve.Evaluate(timer));
            timer += Time.deltaTime * speed;

            if(timer > 0.5f && newImage != null){
                newImage.SetActive(true);
            }
            
            yield return null;
        } 
    }

}
