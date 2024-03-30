using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UIÏÔÊ¾Òþ²Ø")]
    [SerializeField] private GameObject statsBar;
    [SerializeField] private GameObject backpack;

    private void Update()
    {
        
        SetUIswitch(statsBar, KeyCode.I);
        SetUIswitch(backpack, KeyCode.B);

    }

    //UI_Show&Hide
    void SetUIswitch(GameObject go,KeyCode key)
    {
        if (Input.GetKeyUp(key))
            go.SetActive(!go.activeSelf);
    }
    

}
