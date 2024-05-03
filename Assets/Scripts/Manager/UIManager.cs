using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

using Faded;

public class UIManager : Singleton<UIManager>
{
    [Header("Status")]
    [SerializeField] private Slider hpBar;
    [SerializeField] private Slider expBar;

    [Header("Inventory")]
    [SerializeField] private GameObject background;
    
    [SerializeField] private GameObject backpackBar;
    [SerializeField] private GameObject equipmentBar;
    [SerializeField] private GameObject chestBar;

    [SerializeField] private GameObject actionBar;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
            OnBag();
    }



    #region Inventory Show & Hide
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
        removeChildUI(chestBar);
    }

    public void ShowBackpack()
    {
        background.SetActive(true);
        backpackBar.SetActive(true);
        equipmentBar.SetActive(false);
    }

    public void HideBackpack()
    {
        background.SetActive(false);
        backpackBar.SetActive(false);
        removeChildUI(chestBar);
    }
    #endregion

    #region util
    public void SetUp()
    {
        gameObject.GetComponentInChildren<MainMenuWindow>().menu.SetActive(false);
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

    public void removeChildUI(GameObject g)
    {
        foreach (Transform child in g.transform)
        {
            Destroy(child.gameObject);
        }
    }

    #endregion

}