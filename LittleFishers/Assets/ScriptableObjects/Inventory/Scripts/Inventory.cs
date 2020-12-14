using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private string inventoryName;

    [SerializeField]
    private int inventorySize;

    public List<InventorySlot> inventorySlots;

    public int GetInventorySize()
    {
        return this.inventorySize;
    }
}
