using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnVariableChangeDelegate();
[System.Serializable]
public class InventorySlot
{
    public event OnVariableChangeDelegate OnInventoryItemChanged;

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

    public InventoryObject InventoryItem
    {
        get { return _inventoryObject; }
        set
        {
            _inventoryObject = value;
            Debug.Log("Setting InventoryItem");
            if (OnInventoryItemChanged != null) OnInventoryItemChanged();
        }
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
