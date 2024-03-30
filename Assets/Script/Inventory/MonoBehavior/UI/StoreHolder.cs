using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoreHolder : MonoBehaviour
{
    public ItemData_SO itemData;
    public uint price;
    private CharacterStats CharacterStats;
   // private GoodsDisplay goodsDisplay;
    private void Start()
    {
        CharacterStats = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        //goodsDisplay = GetComponentInChildren<GoodsDisplay>();
        //goodsDisplay.syncIcon();
    }

    public void BuyItem()
    { 
        //bool isBackpackFull = false;
        
        //Debug.Log(isBackpackFull);
        if (CharacterStats.characterData.coins >= price  )
        {
            CharacterStats.characterData.coins -=price;
        InventoryManager.Instance.inventoryData.AddItem(itemData, itemData.itemAmount);
        InventoryManager.Instance.inventoryUI.RefreshUI();
        }else 
        {
            Debug.Log(" Failed");
        }
    }
}
