using UnityEngine;
using UnityEngine.EventSystems;


public enum SlotType
{
    BAG, WEAPON, ACTION,
    ARMOR_Head,
    ARMOR_Eye,
    AROMR_Tabard,
    ARMOR_Leg,
    AROMR_Feet,
    } //��Ԫ������: �����ģ� ���������ף��·������
public class SlotHolder : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public SlotType slotType;
    public ItemUI itemUI;


    public void UpdateItem()
    {
        switch(slotType)
        {
            case SlotType.BAG:
                itemUI.bag = InventoryManager.Instance.inventoryData; //��λ��Bag���� ��ӽ���
                break;
            case SlotType.ACTION:
                itemUI.bag = InventoryManager.Instance.actionData;
                break;
            case SlotType.WEAPON:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            //
            case SlotType.ARMOR_Head:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ARMOR_Eye:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.AROMR_Tabard:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ARMOR_Leg:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.AROMR_Feet:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
                //
        }
        var item = itemUI.bag.items[itemUI.Index];
        

        itemUI.SetupItemUI(item.itemData, item.amount);
    }

    #region ��Ʒ˫��ʹ��
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount % 2 == 0)
        {
            UseItem();
        }
    }

    public void UseItem() { 
    if(itemUI.GetItem().itemType == ItemType.Usable && itemUI.bag.items[itemUI.Index].amount > 0) //��Ʒ��ʹ�� ����>0 
        { 
            //�õ���Ʒ���� Ȼ��ִ�� ��Ӧ��ʹ�õķ���
            //GameManager.Instance.playerStats.
        }
        UpdateItem();
    }

    #endregion

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

    #region �ر�ʱִ��
    void OnDisable()
    {
        InventoryManager.Instance.tooltip.gameObject.SetActive(false);
    }
    #endregion

}

