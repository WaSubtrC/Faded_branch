using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
    [SerializeField] private PlayerAvatarController playerAvatarController;

    [Header("Dungeon")]
    [SerializeField] private List<RectTransform> dungeon_spawners;
    [SerializeField] private List<RectTransform> dungeons;
    [SerializeField] private float num_of_active_dungeons;
    private Material material;

    [Header("Global Time")]
    [SerializeField] private TextMeshProUGUI clockText;
    private DateTime time;


    void Start()
    {
        material = background.material;
        material.SetFloat("_Life", 0);

        time = new DateTime(3059, 3, 1, 9, 10, 0);
    }


    void Update()
    {
        OnReviewAtlas();
        OnUpdateWalkTime();
    }

    public void OnUpdateDungeons()
    {

    }

    public void OnTransTown()
    {
        atlas.SetActive(false);
        playerController.enabled = true;
        playerAvatarController.enabled = false;
    }

    public void OnTransDungeon()
    {

    }

    public void OnReviewAtlas()
    {
        if (Input.GetKeyDown(KeyCode.M) && !atlas.activeSelf)
        {
            StartCoroutine(OnTransition());
            playerController.enabled = false;
            playerAvatarController.enabled = false;
        }
    }

    public void OnTransAtlas()
    {
        StartCoroutine(OnTransition());
        playerController.enabled = false;
        playerAvatarController.enabled = true;
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

    private void OnUpdateWalkTime()
    {
        if (atlas.activeSelf) return;

        time = time.AddMinutes(Time.deltaTime);
        clockText.text = $"Year:{time.Year} Mouth:{time.Month} Day:{time.Day}  {time.Hour}:{time.Minute}";
    }

    public void OnUpdateTravelTime()
    {
        time = time.AddHours(Time.deltaTime);
        clockText.text = $"Year:{time.Year} Mouth:{time.Month} Day:{time.Day}  {time.Hour}:{time.Minute}";
    }
}
