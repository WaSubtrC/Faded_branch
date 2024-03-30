using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image icon =null;

    public TextMeshProUGUI amount = null;

    public InventoryData_SO Bag { get; set; }
    public int Index { get; set; } = -1;  //�����λ


    public void SetupItemUI(ItemData_SO item,int itemAmount)
    {
        if(itemAmount == 0)     //����Ϊ0����Ʒɾ����ͼƬGameobject������
        {
            Bag.items[Index].itemData = null;
            icon.gameObject.SetActive(false);
            return;
        }
        
        if (item != null)
        {
            icon.sprite =item.itemIcon;
            
            amount.text = itemAmount.ToString();
            icon.gameObject.SetActive(true);
        }
        else 
        {
            icon.gameObject.SetActive(false);
        }
    }

    public ItemData_SO GetItem()
    {
        return Bag.items[Index].itemData;
    }

}
