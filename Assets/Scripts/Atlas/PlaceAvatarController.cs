using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum PlaceAvatarType{
    DUNGEON, TOWN
}

public class PlaceAvatarController : MonoBehaviour
{
    [Header("Scale for dungeon")] 
    [SerializeField] private PlaceAvatarType type = PlaceAvatarType.DUNGEON;
    [SerializeField] private int layer = 1;
    [SerializeField] private int level = 1;

    [Header("Hints for dungeon")]
    [SerializeField] private TextMeshProUGUI hints;

    void Start()
    {
        
    }

    public void init(int lv)
    {
        level = lv;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Debug.Log("enter");
        }
    }

}
