using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

[RequireComponent(typeof(ItemUI))]
public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    ItemUI currentItemUI;
    SlotHolder currentHolder;
    SlotHolder targettHolder;

    void Awake()
    {
        currentItemUI = GetComponent<ItemUI>();
        currentHolder = GetComponentInParent<SlotHolder>();
        //Debug.Log("currentHolder1:" + currentHolder);
    }

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
            if (InventoryManager.Instance.CheckInInventoryUI(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHolder>())
                { targettHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHolder>(); }

                //Debug.Log(eventData.pointerEnter.gameObject);
                 else
                     targettHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHolder>();

                //判断目标holder 是否 是 原来的holder
                if (targettHolder != InventoryManager.Instance.currentDrag.originalHolder)
                
                    switch (targettHolder.slotType)
                    {
                        case SlotType.BAG:
                            SwapItem();
                            break;
                        case SlotType.WEAPON:
                            break;
                        case SlotType.ACTION:
                            break;
                        case SlotType.ARMOR:
                            break;
                    }
                
                //Debug.Log("currentHolder2:" + currentHolder);
                currentHolder.UpdateItem();
                 targettHolder.UpdateItem();
             }
         }

         transform.SetParent(InventoryManager.Instance.currentDrag.originalParent);

         RectTransform t =transform as RectTransform;
         //解决 拖拽后偏移 问题
         t.offsetMax = -Vector2.one *7; //数字计算 = （相邻的格子【slotHolder】的X/y数值的差）/10
         t.offsetMin = -Vector2.one *7;
     }




    public void SwapItem()
    {
        var targetItem = targettHolder.itemUI.Bag.items[targettHolder.itemUI.Index];
        //Debug.Log("currentHolder3:" + currentHolder);
        var tempItem  =  currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index];

        bool isSameItem = tempItem.itemData ==targetItem.itemData; //物品相同？

        if(isSameItem && targetItem.itemData.stackable) //同物品 and 可堆叠
        {
            targetItem.amount += tempItem.amount;
            tempItem.itemData = null;
            tempItem.amount = 0;
        }
        else
        {
            currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index] = targetItem;
            targettHolder.itemUI.Bag.items[targettHolder.itemUI.Index] = tempItem;
                
        }

    }
                
}      