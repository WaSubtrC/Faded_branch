using UnityEngine;

public enum ItemType {Usable,Armor,Weapon,SpecialItem};   
[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/Item Data")]
public class ItemData_SO : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite itemIcon;
    public int itemAmount;
    public bool stackable;
    [TextArea] 
    public string description;

    [Header("Weapon Info")]
    public GameObject weaponPrefab;

}
