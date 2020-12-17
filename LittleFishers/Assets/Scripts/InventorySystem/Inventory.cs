using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Inventory
{
    [SerializeField]
    private string inventoryName;

    [SerializeField]
    private int inventorySize;

    [SerializeField]
    public List<InventorySlot> inventorySlots;

    public Inventory()
    {
        InitializeInventory("Default Inventory", 16);
    }

    public Inventory(InventoryTemplate inventoryTemplate)
    {
        InitializeInventory(inventoryTemplate.GetInventoryName(), inventoryTemplate.GetInventorySize());
    }

    private void InitializeInventory(string _inventoryName, int _inventorySize)
    {
        this.inventoryName = _inventoryName;
        this.inventorySize = _inventorySize;
        initializeInventorySlots(_inventorySize);
    }

    private void initializeInventorySlots(int _inventorySize)
    {
        inventorySlots = new List<InventorySlot>();
        for (int i = 0; i < _inventorySize; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public void SetInventorySize(int newSize)
    {
        this.inventorySize = newSize;
        if (this.inventorySlots != null) this.inventorySlots.Capacity = newSize;
    }

    public bool AddItem(InventoryObject inventoryObject)
    {
        InventorySlot firstEmptySlot = inventorySlots.Find(slot => slot.IsEmpty);

        if (firstEmptySlot != null)
        {
            firstEmptySlot.SetInventoryObject(inventoryObject);
            return true;
        }

        return false;
    }

    public int GetReservedSlots()
    {
        int counter = 0;
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.IsEmpty) counter++;
        }
        return counter;
    }

    public int SlotCount
    {
        get { return inventorySlots.Count; }
    }
    /*
        private BackpackInventoryItem InstantiateBackpackInventoryItem(InventorySlot allocatedSlot, InventoryObject inventoryObject)
        {
            GameObject backpackItem = GameObject.Instantiate(_backpackInventoryItemPrefab);
            backpackItem.transform.SetParent(GameObject.FindGameObjectWithTag("InventoryItemDragArea").transform);
            BackpackInventoryItem newBackpackInventoryItem = backpackItem.GetComponent<BackpackInventoryItem>();
            backpackItems.Add(newBackpackInventoryItem);
            return newBackpackInventoryItem;
        }
    */
    private bool CanAdd(InventoryObject item)
    {
        if (inventorySlots.Count < inventorySize) return true;
        //TODO Should check for stack size here. 
        return false;
    }

    public void SetInventoryName(string _inventoryName)
    {
        this.inventoryName = _inventoryName;
    }
}
