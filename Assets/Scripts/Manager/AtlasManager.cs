using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


using Faded.Town;
using Faded.Atlas;

public class AtlasManager : Singleton<AtlasManager>
{
    private bool isOpenAtlas = false;

    [Header("Transition Animation")]
    [SerializeField] private Image background;
    [SerializeField] public GameObject atlas;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float duration = 1f;

    [Header("Cross Button")]
    [SerializeField] private GameObject crossButton;

    [Header("Player")]
    [SerializeField] private RectTransform playerAvatar;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAvatarController playerAvatarController;

    [Header("Dungeon")]
    [SerializeField] private List<GameObject> dungeon_spawners;
    private int num_of_dungeons_spawners;

    [SerializeField] private List<GameObject> dungeons;
    [SerializeField] private int num_of_dungeons;

    private Material material;

    [Header("Global Time")]
    [SerializeField] private TextMeshProUGUI clockText;
    private DateTime time;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        material = background.material;
        material.SetFloat("_Life", 0);

        num_of_dungeons_spawners = dungeon_spawners.Count;
        num_of_dungeons = Mathf.Min(num_of_dungeons, num_of_dungeons_spawners);

        time = new DateTime(3059, 3, 1, 9, 10, 0);

        OnSetupDungeons();
    }


    void Update()
    {
        OnReviewAtlas();
        OnUpdateWalkTime();
    }

    public void OnSetupDungeons()
    {
        //Clean up old dungeons
        foreach (var dungeon in dungeon_spawners)
        {
            dungeon.SetActive(false);
        }

        //Generate new dungeons
        System.Random rng = new System.Random();
        List<int> list1 = new List<int>();
        for (int i = 0; i < num_of_dungeons_spawners; i++)
        {
            list1.Add(i);
        }

        List<int> list2 = list1.OrderBy(x => rng.Next()).Take(num_of_dungeons).ToList();
        foreach (var num in list2)
        {
            dungeons.Add(dungeon_spawners[num]);
            dungeon_spawners[num].SetActive(true);
        }
    }

    public void OnTransPlace()
    {
        StartCoroutine(OnTransition(false));
        crossButton.SetActive(false);
        playerController.enabled = true;
        playerAvatarController.enabled = false;
    }

    public void OnReviewAtlas()
    {
        if (Input.GetKeyDown(KeyCode.M) && !atlas.activeSelf)
        {
            StartCoroutine(OnTransition());
            crossButton.SetActive(true);
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

    public void OnTransitionAnim()
    {
        StartCoroutine(OnTransition(false));
    }

    IEnumerator OnTransition(bool isAtlasActive = true)
    {
        float timer = 0;
        while (timer <= duration)
        {
            material.SetFloat("_Life", curve.Evaluate(timer));
            timer += Time.deltaTime * speed;

            if (timer > 0.5f && atlas != null)
            {
                atlas.SetActive(isAtlasActive);
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

    #region Init

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerController = GameObject.Find("The Boy").GetComponent<PlayerController>();
    }
    #endregion
}

