using UnityEngine;
using UnityEngine.EventSystems;


public enum SlotType { BAG,WEAPON,ARMOR,ACTION} //单元格类型 道具格子 物品格子
public class SlotHolder : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public SlotType slotType;
    public ItemUI itemUI;


    public void UpdateItem()
    {
        switch(slotType)
        {
            case SlotType.BAG:
                itemUI.Bag = InventoryManager.Instance.inventoryData; //栏位是Bag类型 添加进入
                break;
            case SlotType.WEAPON:
                break;
            case SlotType.ARMOR:
                break;
            case SlotType.ACTION:
                break;

        }
        var item = itemUI.Bag.items[itemUI.Index];
        

        itemUI.SetupItemUI(item.itemData, item.amount);
    }

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

    #region 物品双击使用
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount % 2 == 0)
        {
            UseItem();
        }
    }

    public void UseItem() { 
    if(itemUI.GetItem().itemType == ItemType.Usable && itemUI.Bag.items[itemUI.Index].amount > 0) //物品可使用 数量>0 
        { 
            //拿到物品数据 然后执行 对应的使用的方法
            //GameManager.Instance.playerStats.
        }
        UpdateItem();
    }

    #endregion

    #region 关闭时执行
    void OnDisable()
    {
        InventoryManager.Instance.tooltip.gameObject.SetActive(false);
    }
    #endregion

}

