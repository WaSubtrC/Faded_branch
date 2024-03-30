using UnityEngine;

public class ContainerUI : MonoBehaviour
{
    public SlotHolder[] slotHolders;
    public void RefreshUI()
    {
        for (int i = 0;i < slotHolders.Length; i++) 
        {
            slotHolders[i].itemUI.Index = i;
            slotHolders[i].UpdateItem();
        }

    }
}
