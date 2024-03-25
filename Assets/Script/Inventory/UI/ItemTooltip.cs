using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public TextMeshProUGUI ItemNameText;
    public TextMeshProUGUI ItemInfoText;

    public void SetupTooltip(ItemData_SO item)
    {
        ItemNameText.text = item.itemName;
        ItemInfoText.text = item.description;


    }
}
