using UnityEngine;
using UnityEngine.EventSystems;


public enum SlotType { BAG,WEAPON,ARMOR,ACTION} //��Ԫ������ ���߸��� ��Ʒ����
public class SlotHolder : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler//,IPointerClickHandler
{
    public SlotType slotType;
    public ItemUI itemUI;

    public void UpdateItem()
    {
        switch(slotType)
        {
            case SlotType.BAG:
                itemUI.Bag = InventoryManager.Instance.inventoryData; //��λ��Bag���� ������ӽ���
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
