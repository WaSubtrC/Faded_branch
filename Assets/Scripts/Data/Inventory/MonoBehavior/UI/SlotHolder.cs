using UnityEngine;
using UnityEngine.EventSystems;


namespace Faded.Town {
public enum SlotType
{
    BAG, 
    WEAPON,
    ACTION,
    ARMOR_HEAD,
    ARMOR_EYE,
    AROMR_BODY,
    ARMOR_LEG,
    AROMR_FEET,
    SOLD, 
    CHEST,
    } 

public class SlotHolder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public SlotType slotType;
    public ItemUI itemUI;


    public void UpdateItem()
    {
        switch(slotType)
        {
            case SlotType.BAG:
                itemUI.bag = InventoryManager.Instance.inventoryData; 
                break;
            case SlotType.ACTION:
                itemUI.bag = InventoryManager.Instance.actionData;
                break;
            case SlotType.WEAPON:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.CHEST:
                itemUI.bag = InventoryManager.Instance.chestData;
                break;
            //
            case SlotType.ARMOR_HEAD:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ARMOR_EYE:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.AROMR_BODY:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ARMOR_LEG:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.AROMR_FEET:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
                //
            case SlotType.SOLD:
                itemUI.bag = InventoryManager.Instance.soldData;
                break;
        }
        var item = itemUI.bag.items[itemUI.Index];
        

        itemUI.SetupItemUI(item.itemData, item.amount);
    }

    #region 物品双击 方法
    public void OnPointerClick(PointerEventData eventData)
    {
       // Double Click
        if(eventData.clickCount % 2 == 0)
        {
                if(itemUI.GetItem() == null)
                {
                    return;
                }
                if(InventoryManager.Instance.isSelling)
                {
                    if (slotType == SlotType.BAG )
                    {
                        SellItem();
                    } else if (slotType == SlotType.SOLD)
                    {
                        BuyBackItem();

                    }
                }
                else
                {
                    UseItem();
                }
        }
    }

    public void UseItem() {
            if (itemUI.bag.items[itemUI.Index].amount > 0) //物品可使用 数量>0 
            {
                if(itemUI.GetItem().itemType == ItemType.POTION)
                {

                }else if(itemUI.GetItem().itemType == ItemType.ARTIFACT)
                {

                }


            }
            else 
            { 
                Debug.Log("The item cannot be used"); 
                return; 
            }
            UpdateItem();
    }

    public void SellItem()
    {
        if(itemUI.GetItem().CanBeSold== true && itemUI.bag.items[itemUI.Index].amount > 0) 
        {
                Debug.Log("sell");
                var itemPrice = itemUI.GetItem().soldPrice;
                GameManager.Instance.playerStats.playerData.coins += itemPrice;
                
                InventoryManager.Instance.soldData.AddItem(itemUI.GetItem(), 1);
                InventoryManager.Instance.soldContainerUI.RefreshUI();

                InventoryManager.Instance.inventoryData.RemoveItem(itemUI.GetItem(), 1);
                InventoryManager.Instance.inventoryUI.RefreshUI();

        }
        UpdateItem();
    }

    public void BuyBackItem()
    {
        if (itemUI.GetItem().CanBeSold == true && itemUI.bag.items[itemUI.Index].amount > 0)
        {
                var itemPrice = itemUI.GetItem().soldPrice;
                if(GameManager.Instance.playerStats.playerData.coins >= itemPrice )
                    GameManager.Instance.playerStats.playerData.coins -= itemPrice;

                InventoryManager.Instance.inventoryData.AddItem(itemUI.GetItem(), 1);
                InventoryManager.Instance.inventoryUI.RefreshUI();

                InventoryManager.Instance.soldData.RemoveItem(itemUI.GetItem(), 1);
                InventoryManager.Instance.soldContainerUI.RefreshUI();
        }
    }

    #endregion

    #region 物品提示框
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(itemUI.GetItem())
        {
            InventoryManager.Instance.tooltip.SetupTooltip(itemUI.GetItem());
            InventoryManager.Instance.tooltip.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.tooltip.gameObject.SetActive(false);
    }
    #endregion

    #region 关闭时执行
    void OnDisable()
    {
        if(InventoryManager.Instance != null)
        {
        InventoryManager.Instance.tooltip.gameObject.SetActive(false);
        }

    }
    #endregion

}

}
