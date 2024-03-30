using UnityEngine;
using UnityEngine.EventSystems;


public enum SlotType { BAG,WEAPON,ARMOR,ACTION} //��Ԫ������ ���߸��� ��Ʒ����
public class SlotHolder : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public SlotType slotType;
    public ItemUI itemUI;


    public void UpdateItem()
    {
        switch(slotType)
        {
            case SlotType.BAG:
                itemUI.Bag = InventoryManager.Instance.inventoryData; //��λ��Bag���� ��ӽ���
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

    #region ��Ʒ��ʾ��
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

    #region ��Ʒ˫��ʹ��
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount % 2 == 0)
        {
            UseItem();
        }
    }

    public void UseItem() { 
    if(itemUI.GetItem().itemType == ItemType.Usable && itemUI.Bag.items[itemUI.Index].amount > 0) //��Ʒ��ʹ�� ����>0 
        { 
            //�õ���Ʒ���� Ȼ��ִ�� ��Ӧ��ʹ�õķ���
            //GameManager.Instance.playerStats.
        }
        UpdateItem();
    }

    #endregion

    #region �ر�ʱִ��
    void OnDisable()
    {
        InventoryManager.Instance.tooltip.gameObject.SetActive(false);
    }
    #endregion

}

