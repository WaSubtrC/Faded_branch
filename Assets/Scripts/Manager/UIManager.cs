using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

using Faded;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject backpackBar;
    [SerializeField] private GameObject equipmentBar;
    [SerializeField] private GameObject actionBar;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        actionBar.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
            OnBag();
    }

    public void SetUp()
    {
        gameObject.GetComponentInChildren<MainMenuWindow>().menu.SetActive(false);
    }

    public void OnBag()
    {
        if (equipmentBar.activeSelf)
            HideBag();
        else
            ShowBag();
    }

    public void ShowBag()
    {
        background.SetActive(true);
        backpackBar.SetActive(true);
        equipmentBar.SetActive(true);
    }

    public void HideBag()
    {
        background.SetActive(false);
        backpackBar.SetActive(false);
        equipmentBar.SetActive(false);
    }

    public void ShowBackpack()
    {
        background.SetActive(true);
        backpackBar.SetActive(true);
    }

    public void HideBackpack()
    {
        background.SetActive(false);
        backpackBar.SetActive(false);
    }

    private bool InteractWithUI()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        else
            return false;
    }


}