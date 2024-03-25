using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Usable,Armor,Weapon};   
[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/Item Data")]
public class ItemData_SO : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemIcon;
    public int itemAmount;
    public bool stackable;
    [TextArea] 
    public string description;

    [Header("Weapon Info")]
    public GameObject weaponPrefab;
}
