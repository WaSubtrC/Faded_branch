using UnityEngine;
using UnityEngine.EventSystems;

namespace FadedTown {
public class DragPanel : MonoBehaviour, IDragHandler,IPointerDownHandler
{
    RectTransform rectTransform;
    Canvas canvas;
    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //Debug.Log(InventoryManager.Instance);
        //游戏启动默认不 setActive(true) 层级面板中 挂载DragPanel 的物体--否则会报错
        canvas = InventoryManager.Instance.GetComponent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //eventData.delta指针增量  除以 比例
        //Debug.Log("");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.SetSiblingIndex(1); // 括号数字--数字越大 图层在前 * 保证DragPanel在数字最大
    }
}
}
