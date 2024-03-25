using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoodsDisplay : MonoBehaviour
{
    public Image icon = null;
    public TextMeshProUGUI PriceText = null;
    private StoreHolder parentStoreHolder;

    private void Start()
    {
        parentStoreHolder = GetComponentInParent<StoreHolder>();
        syncIcon();

    }
    public void syncIcon()
    {
        icon.sprite = parentStoreHolder.itemData.itemIcon;
        PriceText.text = parentStoreHolder.price.ToString()+"$";

    }



}
