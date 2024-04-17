using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AtlasManager : Singleton<AtlasManager>
{
    private bool isOpenAtlas = false;

    [Header("Transition Animation")]
    [SerializeField] private Image background;
    [SerializeField] private GameObject atlas;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float duration = 1f;

    [Header("Player")]
    [SerializeField] private RectTransform playerAvatar;
    [SerializeField] private PlayerController playerController; 

    [Header("Dungeon")]
    public List<Vector3> dungeons;
    private Material material;


    void Start()
    {
        material = background.material;
        material.SetFloat("_Life", 0);
    }


    void Update()
    {

    }

    public void OnTransTown()
    {
        atlas.SetActive(false);
        playerController.enabled = true;
    }

    public void OnTransDungeon()
    {

    }

    public void OnTransAtlas()
    {
        StartCoroutine(OnTransition());
        playerController.enabled = false;
    }

    IEnumerator OnTransition()
    {
        float timer = 0;
        while (timer <= duration)
        {
            material.SetFloat("_Life", curve.Evaluate(timer));
            timer += Time.deltaTime * speed;

            if (timer > 0.5f && atlas != null)
            {
                atlas.SetActive(true);
            }

            yield return null;
        }
    }


}
