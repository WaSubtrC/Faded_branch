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

        //记录原始数据
        InventoryManager.Instance.currentDrag = new InventoryManager.DragData();
        InventoryManager.Instance.currentDrag.originalHolder = GetComponentInParent<SlotHolder>();
        InventoryManager.Instance.currentDrag.originalParent = (RectTransform)transform.parent;

        transform.SetParent(InventoryManager.Instance.dragCanvas.transform, true);

    }

    public void OnDrag(PointerEventData eventData)
    {
        //跟随鼠标移动拖拽
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //结束拖拽 放下物品 交互数据
        //是否指向UI物品
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
                //目标holder != 原来的holder
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
         //解决 拖拽后物品错位 问题
         t.offsetMax = -Vector2.one *1f; 
         t.offsetMin = -Vector2.one *1f;
     }

    #endregion


    public void SwapItem()
    {
        var targetItem = targettHolder.itemUI.bag.items[targettHolder.itemUI.Index];
        
        var tempItem  =  currentHolder.itemUI.bag.items[currentHolder.itemUI.Index];

        bool isSameItem = tempItem.itemData ==targetItem.itemData; //物品相同？

        if(isSameItem && targetItem.itemData.stackable) //同物品 and 可堆叠
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