using UnityEngine;
using UnityEngine.UIElements;

using FadedTown;

public class InventoryManager : Singleton<InventoryManager>
{
    public class DragData
    {
        public SlotHolder originalHolder;
        public RectTransform originalParent;
    }

    [Header("Inventory Data")]
    [Header("Inventory DataTemplate")]
    public InventoryData_SO inventoryTemplate;
    public InventoryData_SO equipmentTemplate;
    public InventoryData_SO actionTemplate;
    

    [Header("Inventory Data")]
    public InventoryData_SO inventoryData;
    public InventoryData_SO equipmentData;
    public InventoryData_SO actionData;
    public InventoryData_SO chestData;
    public InventoryData_SO soldData;

    [Header("Containers")]
    public ContainerUI inventoryUI;
    public ContainerUI equipmentUI;
    public ContainerUI actionUI;
    public ContainerUI chestContainerUI;
    public ContainerUI soldContainerUI;

    [Header("Drag Canvas")]
    public Canvas dragCanvas;
    public DragData currentDrag;

    [Header("Stats Text")]

    public TextAlignment healthText;
    public TextAlignment attackText;

    [Header("Tooltip")]
    public ItemTooltip tooltip;

    [Header("UI")]
    public bool isSelling;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);

        AssignFromTemplete(inventoryTemplate, ref inventoryData);
        AssignFromTemplete(equipmentTemplate, ref equipmentData);
        AssignFromTemplete(actionTemplate, ref actionData);
    }


    void Start()
    {
        inventoryUI.RefreshUI();
        equipmentUI.RefreshUI();
        actionUI.RefreshUI();
    }

    #region reference functions
    //检查拖拽物品是否在每个Slot范围内
    //新增ui加在||后
    public bool CheckInAll(Vector3 position) 
    {
        return CheckInUI(position, inventoryUI) ||
               CheckInUI(position, equipmentUI) || 
               CheckInUI(position, actionUI)   ||
               CheckInUI(position, chestContainerUI);
    }

    public void SetChestData(InventoryData_SO originData)
    {
        chestData = originData;
        chestContainerUI = GameObject.Find("ChestUI(Clone)").GetComponentInChildren<ContainerUI>();
        chestContainerUI.RefreshUI();
        if(chestContainerUI == null)
        {
            Debug.LogError("ChestUI(Clone)对象为空，无法找到容器。");
        }
    }


    public void SetSoldData(InventoryData_SO originData)
    {
        soldData = originData;    
        soldContainerUI = GameObject.Find("SoldUI(Clone)").GetComponentInChildren<ContainerUI>();
        soldContainerUI.RefreshUI();    
        if (soldContainerUI == null)
        {
            Debug.LogError("SoldUI(Clone)对象为空，无法找到容器。");
        }
    }
    #endregion

    #region help functions
    public void AssignFromTemplete(InventoryData_SO template, ref InventoryData_SO data)
    {
        if (template != null)
        {
            data = Instantiate(template);
        }
        else
        {
            Debug.LogError(template+"模板对象为空，无法创建副本。");
        }
    }

    public bool CheckInUI(Vector3 position,ContainerUI containerUI)
    {
        foreach (var slotHolder in containerUI.slotHolders) 
        {
            RectTransform t = slotHolder.transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
                return true;
        }
        return false;
    }



    #endregion
}