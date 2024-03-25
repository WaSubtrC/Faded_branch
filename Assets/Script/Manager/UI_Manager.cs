using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject pickUpTIPS;
    //private List<ItemPickUp> itemPickUps;
    //private void Start()
    //{
    //    ItemPickUp itemPickUp = pickUpTIPS.GetComponent<ItemPickUp>();
    //    foreach(var item in itemPickUps) 
    //    {

    //    }
    //}
    //private void Update()
    //{
    //    // 在这里检查道具是否已经被拾取
    //    if (pickUpTIPS != null)
    //    {
    //        // 获取与当前空物体关联的道具游戏对象


    //        // 检查道具是否已经被拾取
    //        if (itemPickUps != null && itemPickUps.isPicked)
    //        {
    //            // 执行相应的操作，比如隐藏提示UI等
    //                pickUpTIPS.SetActive(false);
    //        }
    //    }
    //}
    public void ItemTIPS_Controller(bool isActive)
    {
       pickUpTIPS.SetActive(isActive);
    }
}
