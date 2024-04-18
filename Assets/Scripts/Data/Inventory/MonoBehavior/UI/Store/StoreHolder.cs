using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreHolder : MonoBehaviour
{
    public ItemData_SO itemData;
    public int cost;
    private PlayerStatus CharacterStats;
    // private GoodsDisplay goodsDisplay;
    private void Start()
    {
        CharacterStats = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        //goodsDisplay = GetComponentInChildren<GoodsDisplay>();
        //goodsDisplay.syncIcon();
    }

    public void BuyItem()
    { 
        //bool isBackpackFull = false;
        
        //Debug.Log(isBackpackFull);
        if (CharacterStats.characterData.coins >= cost  )
        {
            CharacterStats.characterData.coins -=cost;
        InventoryManager.Instance.inventoryData.AddItem(itemData,1); //itemData.itemAmount
        InventoryManager.Instance.inventoryUI.RefreshUI();
        }else 
        {
            Debug.Log("Buy Item Failed");
        }
    }
}
