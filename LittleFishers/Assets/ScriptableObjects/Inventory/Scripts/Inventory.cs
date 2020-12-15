using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private string inventoryName;

    [SerializeField]
    private int inventorySize;

    private LittleFishersUI littleFishersUI;

    public List<InventorySlot> inventorySlots;

    public int GetInventorySize()
    {
        return this.inventorySize;
    }

    public bool AddItem(ItemObject item, int count)
    {
        if (!littleFishersUI)
            littleFishersUI = GameObject.Find("LittleFishersUI").GetComponent<LittleFishersUI>();

        if (CanAddItem(item, count))
        {
            inventorySlots.Add(new InventorySlot(item, count));
            littleFishersUI.UpdateUI();
            return true;
        }
        return false;
    }

    private bool CanAddItem(ItemObject item)
    {
        return CanAddItem(item, 1);
    }

    private bool CanAddItem(ItemObject item, int count)
    {
        if (inventorySlots.Count < inventorySize) return true;
        //TODO Should check for stack size here. 
        return false;
    }
}
