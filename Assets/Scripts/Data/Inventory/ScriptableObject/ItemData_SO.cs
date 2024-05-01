using UnityEngine;

public enum ItemType 
{
    Usable,
    Weapon,
    SpecialItem,
    stuff,
    Armor_Head,
    Armor_Eye,
    Armor_Tabard,
    Armor_Leg,
    Armor_Feet,
};   

[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/Item Data")]
public class ItemData_SO : ScriptableObject
{
    [Header("General Info")]
    public string itemName ;
    public ItemType itemType;
    public Sprite itemIcon;
    public int itemAmount = 1;
    public bool stackable;
    public int id; 
    [TextArea] 
    public string description;

    [Header("Property Info")]
    public bool CanBeSold;
    public int soldPrice;

    [Header("Weapon Info")]
    public GameObject weaponPrefab;

}
