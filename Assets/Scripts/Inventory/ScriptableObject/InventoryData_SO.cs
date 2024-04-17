using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory/Inventory Data")]
public class InventoryData_SO : ScriptableObject
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public void AddItem(ItemData_SO newItemData,int amount)
    {
        bool found =false;
        //物品有无？ 有->是相同物品？->*可堆叠?->amount++ *-->不可堆叠->下一栏位创建 /无 ->指定位置创建
        if(newItemData.stackable ) //可堆叠         
        {
            foreach(var item in items)
            {
                if(item.itemData == newItemData)
                {
                    item.amount += amount;
                    found =true;
                    break;
                }
            }
        }

        for(int i = 0; i < items.Count;i++) //list0~count遍历找空栏位->创建
            {
                if(items[i].itemData == null && !found)
                {
                    items[i].itemData = newItemData;
                    items[i].amount =amount;
                    break;
                }
            }
    }
}

[System.Serializable]
public class InventoryItem
    {
        public ItemData_SO itemData;
        public int amount;

    }

