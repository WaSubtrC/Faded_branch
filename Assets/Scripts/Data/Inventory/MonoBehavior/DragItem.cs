using UnityEngine;
using UnityEngine.EventSystems;

namespace Faded.Town
{
    [RequireComponent(typeof(ItemUI))]

    public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private ItemUI currentItemUI;
        private SlotHolder currentHolder;
        private SlotHolder targetHolder;
        private ItemUI targetItemUI;

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
                        targetHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHolder>();
                        targetItemUI = targetHolder.itemUI;

                    }

                    else
                    {
                        targetHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHolder>();
                        targetItemUI = targetHolder.itemUI;
                    }
                    //目标holder != 原来的holder
                    if (targetHolder != InventoryManager.Instance.currentDrag.originalHolder)
                        switch (targetHolder.slotType)
                        {
                            case SlotType.BAG:
                                SwapController();
                                break;
                            case SlotType.CHEST:
                                SwapController();
                                break;
                            case SlotType.WEAPON:
                                SwapController(ItemType.WEAPON);
                                break;
                            case SlotType.ACTION:
                                SwapController();
                                break;
                            case SlotType.ARMOR_HEAD:
                                SwapController(ItemType.ARMOR_HEAD);
                                break;
                            case SlotType.ARMOR_EYE:
                                SwapController(ItemType.ARMOR_EYE);
                                break;
                            case SlotType.AROMR_BODY:
                                SwapController(ItemType.ARMOR_BODY);
                                break;
                            case SlotType.ARMOR_LEG:
                                SwapController(ItemType.ARMOR_LEG);
                                break;
                            case SlotType.AROMR_FEET:
                                SwapController(ItemType.ARMOR_FEET);
                                break;
                            case SlotType.SOLD:
                                SwapController();
                                break;
                        }
                    currentHolder.UpdateItem();
                    targetHolder.UpdateItem();
                }
            }

            transform.SetParent(InventoryManager.Instance.currentDrag.originalParent);

            RectTransform t = transform as RectTransform;
            //解决 拖拽后物品错位 问题
            t.offsetMax = -Vector2.one * 1f;
            t.offsetMin = -Vector2.one * 1f;
        }

        private void SwapController(ItemType targetItemType)
        {
            if (currentHolder.slotType == targetHolder.slotType || currentItemUI.GetItem().itemType == targetItemType)
            {
                SwapItem();
            }
        }

        private void SwapController()
        {
            if (currentHolder.slotType == targetHolder.slotType || targetItemUI.GetItem() == null || currentItemUI.GetItem().itemType == targetItemUI.GetItem().itemType)
            {
                SwapItem();
            }
        }


        #endregion


        public void SwapItem()
        {
            var targetItem = targetHolder.itemUI.bag.items[targetHolder.itemUI.Index];

            var tempItem = currentHolder.itemUI.bag.items[currentHolder.itemUI.Index];

            bool isSameItem = tempItem.itemData == targetItem.itemData; //物品相同？

            if (isSameItem && targetItem.itemData.stackable) //同物品 and 可堆叠
            {
                targetItem.amount += tempItem.amount;
                tempItem.itemData = null;
                tempItem.amount = 0;
            }
            else
            {
                currentHolder.itemUI.bag.items[currentHolder.itemUI.Index] = targetItem;
                targetHolder.itemUI.bag.items[targetHolder.itemUI.Index] = tempItem;

            }

        }

    }
}
