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

    public ItemObject GetInventoryItem()
    {
        return this.inventoryObject;
    }
}
