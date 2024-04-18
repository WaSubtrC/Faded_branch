using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject statsBar;
    //[SerializeField] private KeyCode keyCode;
    [SerializeField] private GameObject backpack;
    [SerializeField] private GameObject equipment;
    [SerializeField] private GameObject actionContainer;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        actionContainer.SetActive(true);
        //StartCoroutine(ActivateActionBarAfterDelay());
    }

    private void Update()
    {
        SetUIswitch(statsBar, KeyCode.I);
        SetUIswitch(equipment, KeyCode.I);
        SetUIswitch(backpack, KeyCode.I);
    }

    //UI_Show&Hide
    void SetUIswitch(GameObject go, KeyCode key)
    {
        if (Input.GetKeyUp(key))
            go.SetActive(!go.activeSelf);
    }

    private bool InteractWithUI()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()){
            return true;
        }
        else 
            return false;
    }
}
