using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreGoodsDisplay : MonoBehaviour
{
    public Image icon = null;
    public TextMeshProUGUI costText = null;
    public TextMeshProUGUI itemName  = null;
    private StoreHolder parentStoreHolder;

    private void Start()
    {
        parentStoreHolder = GetComponentInParent<StoreHolder>();
        SyncItemInfo();

    }
    public void SyncItemInfo()
    {
        icon.sprite = parentStoreHolder.itemData.itemIcon;
        costText.text = parentStoreHolder.cost.ToString();
        itemName.text = parentStoreHolder.itemData.name.ToString();
    }



}
