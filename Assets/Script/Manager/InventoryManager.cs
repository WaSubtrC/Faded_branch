using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public class DragData
    {
        public SlotHolder originalHolder;
        public RectTransform originalParent;
    }

    [Header("Inventory Data")]
    public InventoryData_SO inventoryTemplete;//���� �ض��������� ��ģ�� 
    [HideInInspector]public InventoryData_SO inventoryData;

    [Header("Containers")]
    public ContainerUI inventoryUI;

    [Header("Drag Canvas")]
    public Canvas dragCanvas;
    public DragData currentDrag;

    [Header("Stats Text")]

    public TextAlignment healthText;

    public TextAlignment attackText;
    [Header("Tooltip")]
    public ItemTooltip tooltip;

    protected override void Awake()
    {
        base.Awake();

        AssignFromTemplete(ref inventoryTemplete, ref inventoryData);



        void AssignFromTemplete(ref InventoryData_SO templete, ref InventoryData_SO _data)
        {
            if (templete != null)
            { _data = Instantiate(templete); }
        }
    }


    void Start()
    {

        inventoryUI.RefreshUI();
    }

    void Update()
    {

    }



    //�����ק��Ʒ�Ƿ���ÿ��Slot��Χ��
    public bool CheckInInventoryUI(Vector3 position)
    {
        for (int i = 0; i < inventoryUI.slotHolders.Length; i++)
        {
            RectTransform t = inventoryUI.slotHolders[i].transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }

        }
        return false;
    }
}