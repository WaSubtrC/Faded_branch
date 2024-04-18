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
    public int layer = 1;
    public int level = 1;

    [Header("Hints for dungeon")]
    [SerializeField] private TextMeshProUGUI hints;

    void Start()
    {
        
    }

    public void init(int lv)
    {
        level = Mathf.Max(1, lv + Random.Range((int)-2, (int)3));
        layer = 1 + Random.Range((int)0, (int)2);
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
            Debug.Log("Enter the dungeon");
            AtlasManager.Instance.OnTransDungeon(this);
        }
    }

}
