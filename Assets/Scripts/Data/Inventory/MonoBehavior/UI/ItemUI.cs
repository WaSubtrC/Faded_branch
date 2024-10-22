using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Faded.Town {
public class ItemUI : MonoBehaviour
{
    public Image icon =null;

    public TextMeshProUGUI amount = null;

    public InventoryData_SO bag { get; set; }
    public int Index { get; set; } = -1;  //避免错位


    public void SetupItemUI(ItemData_SO item, int itemAmount)
    {
        if(itemAmount == 0)     //数量为0，物品删除，图片Gameobject不激活
        {
            bag.items[Index].itemData = null;
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
        return bag.items[Index].itemData;
    }

}
}
