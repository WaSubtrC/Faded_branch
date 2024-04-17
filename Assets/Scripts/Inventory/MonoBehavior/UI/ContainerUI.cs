using UnityEngine;

public class ContainerUI : MonoBehaviour
{
    public SlotHolder[] slotHolders;
    public void RefreshUI()
    {
        int index = 0;
        foreach (var holder in slotHolders)
        {
            holder.itemUI.Index = index++;
            holder.UpdateItem();
        }
    }
}
