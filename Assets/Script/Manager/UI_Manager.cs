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
    //    // ������������Ƿ��Ѿ���ʰȡ
    //    if (pickUpTIPS != null)
    //    {
    //        // ��ȡ�뵱ǰ����������ĵ�����Ϸ����


    //        // �������Ƿ��Ѿ���ʰȡ
    //        if (itemPickUps != null && itemPickUps.isPicked)
    //        {
    //            // ִ����Ӧ�Ĳ���������������ʾUI��
    //                pickUpTIPS.SetActive(false);
    //        }
    //    }
    //}
    public void ItemTIPS_Controller(bool isActive)
    {
       pickUpTIPS.SetActive(isActive);
    }
}
