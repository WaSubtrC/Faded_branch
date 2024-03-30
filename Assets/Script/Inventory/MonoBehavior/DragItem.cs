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
            if (InventoryManager.Instance.CheckInInventoryUI(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHolder>())
                { targettHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHolder>(); }

                //Debug.Log(eventData.pointerEnter.gameObject);
                 else
                     targettHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHolder>();

                //�ж�Ŀ��holder �Ƿ� �� ԭ����holder
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
         //��� ��ק��ƫ�� ����
         t.offsetMax = -Vector2.one *7; //���ּ��� = �����ڵĸ��ӡ�slotHolder����X/y��ֵ�Ĳ/10
         t.offsetMin = -Vector2.one *7;
     }




    public void SwapItem()
    {
        var targetItem = targettHolder.itemUI.Bag.items[targettHolder.itemUI.Index];
        //Debug.Log("currentHolder3:" + currentHolder);
        var tempItem  =  currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index];

        bool isSameItem = tempItem.itemData ==targetItem.itemData; //��Ʒ��ͬ��

        if(isSameItem && targetItem.itemData.stackable) //ͬ��Ʒ and �ɶѵ�
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