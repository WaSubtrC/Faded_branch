using UnityEngine;

public enum ItemType 
{
    ARMOR_HEAD,
    ARMOR_EYE,
    ARMOR_BODY,
    ARMOR_LEG,
    ARMOR_FEET,
    WEAPON,
    POTION,
    FOOD,
    STUFF,
    BOOK,
    ARTIFACT,

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

    [Header("Attribute Gain Info")]
    public float speed;
    public float damage;
    public float defense;

    [Header("Use Info")]
    public float cd;
}
