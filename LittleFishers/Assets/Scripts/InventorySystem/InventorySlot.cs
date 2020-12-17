using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField]
    private InventoryObject _inventoryObject;

    public InventorySlot()
    {
        _inventoryObject = null;
    }

    public InventorySlot(InventoryObject inventoryObject)
    {
        _inventoryObject = inventoryObject;
    }

    public int GetAmount()
    {
        return _inventoryObject.amount;
    }

    public void SetInventoryObject(InventoryObject inventoryItem)
    {
        this._inventoryObject = inventoryItem;
    }

    public InventoryObject GetInventoryObject()
    {
        return this._inventoryObject;
    }

    public bool IsEmpty
    {
        get
        {
            if (this._inventoryObject == null) return true;
            if (this._inventoryObject.IsEmpty) return true;
            return false;
        }
    }
}
