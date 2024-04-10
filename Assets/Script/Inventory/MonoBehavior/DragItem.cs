using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(ItemUI))]
public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
      private ItemUI currentItemUI;
      private SlotHolder currentHolder;
      private  SlotHolder targettHolder;

    void Awake()
    {
        currentItemUI = GetComponent<ItemUI>();
        currentHolder = GetComponentInParent<SlotHolder>();
        
    }

    #region Drag Interface

    public void OnBeginDrag(PointerEventData eventData)
    {

        //��¼ԭʼ����
        InventoryManager.Instance.currentDrag = new InventoryManager.DragData();
        InventoryManager.Instance.currentDrag.originalHolder = GetComponentInParent<SlotHolder>();
        InventoryManager.Instance.currentDrag.originalParent = (RectTransform)transform.parent;

        transform.SetParent(InventoryManager.Instance.dragCanvas.transform, true);

    }

    public void OnDrag(PointerEventData eventData)
    {
        //��������ƶ���ק
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //������ק ������Ʒ ��������
        //�Ƿ�ָ��UI��Ʒ
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (InventoryManager.Instance.CheckInAll(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHolder>())
                {
                    targettHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHolder>();                  
                }

                else
                {
                    targettHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHolder>();
                    
                }
                //Ŀ��holder != ԭ����holder
                if (targettHolder != InventoryManager.Instance.currentDrag.originalHolder)
                switch (targettHolder.slotType)
                    {
                        case SlotType.BAG:
                            SwapItem();
                            break;
                        case SlotType.WEAPON:
                            if (currentItemUI.bag.items[currentItemUI.Index].itemData.itemType == ItemType.Weapon)
                            SwapItem();
                            break;
                        case SlotType.ACTION:
                            SwapItem();
                            break;
                        //
                        case SlotType.ARMOR_Head:
                            if (currentItemUI.bag.items[currentItemUI.Index].itemData.itemType == ItemType.Armor_Head)
                                SwapItem();
                            break;
                        case SlotType.ARMOR_Eye:
                            if (currentItemUI.bag.items[currentItemUI.Index].itemData.itemType == ItemType.Armor_Eye)
                                SwapItem();
                            break;
                        case SlotType.AROMR_Tabard:
                            if (currentItemUI.bag.items[currentItemUI.Index].itemData.itemType == ItemType.Armor_Tabard)
                                SwapItem();
                            break;
                        case SlotType.ARMOR_Leg:
                            if (currentItemUI.bag.items[currentItemUI.Index].itemData.itemType == ItemType.Armor_Leg)
                                SwapItem();
                            break;
                        case SlotType.AROMR_Feet:
                            if (currentItemUI.bag.items[currentItemUI.Index].itemData.itemType == ItemType.Armor_Feet)
                                SwapItem();
                            break;
                    }
                
                //Debug.Log("currentHolder2:" + currentHolder);
                currentHolder.UpdateItem();
                targettHolder.UpdateItem();
             }
         }

         transform.SetParent(InventoryManager.Instance.currentDrag.originalParent);

         RectTransform t =transform as RectTransform;
         //��� ��ק����Ʒ��λ ����
         t.offsetMax = -Vector2.one *1f; 
         t.offsetMin = -Vector2.one *1f;
     }

    #endregion


    public void SwapItem()
    {
        var targetItem = targettHolder.itemUI.bag.items[targettHolder.itemUI.Index];
        
        var tempItem  =  currentHolder.itemUI.bag.items[currentHolder.itemUI.Index];

        bool isSameItem = tempItem.itemData ==targetItem.itemData; //��Ʒ��ͬ��

        if(isSameItem && targetItem.itemData.stackable) //ͬ��Ʒ and �ɶѵ�
        {
            targetItem.amount += tempItem.amount;
            tempItem.itemData = null;
            tempItem.amount = 0;
        }
        else
        {
            currentHolder.itemUI.bag.items[currentHolder.itemUI.Index] = targetItem;
            targettHolder.itemUI.bag.items[targettHolder.itemUI.Index] = tempItem;
                
        }

    }
                
}      