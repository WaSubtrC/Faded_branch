using UnityEngine;
using UnityEngine.EventSystems;


public enum SlotType { BAG,WEAPON,ARMOR,ACTION} //单元格类型 道具格子 物品格子
public class SlotHolder : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler//,IPointerClickHandler
{
    public SlotType slotType;
    public ItemUI itemUI;

    public void UpdateItem()
    {
        switch(slotType)
        {
            case SlotType.BAG:
                itemUI.Bag = InventoryManager.Instance.inventoryData; //栏位是Bag类型 才能添加进入
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







}
