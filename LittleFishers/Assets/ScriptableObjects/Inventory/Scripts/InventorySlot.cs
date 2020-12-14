using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField]
    private ItemObject inventoryObject;
    [SerializeField]
    private int amount;

    public InventorySlot(ItemObject _inventoryObject, int _amount)
    {
        inventoryObject = _inventoryObject;
        amount = _amount;
    }

    public ItemObject GetInventoryItem()
    {
        return this.inventoryObject;
    }
}
