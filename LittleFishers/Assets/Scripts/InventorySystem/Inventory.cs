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

    [SerializeField]
    private int gold;

    public Inventory()
    {
        InitializeInventory("Default Inventory", 16, 0, null);
    }

    public Inventory(InventoryTemplate inventoryTemplate)
    {
        InitializeInventory(inventoryTemplate.GetInventoryName(), inventoryTemplate.GetInventorySize(), inventoryTemplate.GetGold(), null);
    }

    public Inventory(InventoryTemplate inventoryTemplate, OnVariableChangeDelegate onInventoryItemChanged)
    {
        InitializeInventory(inventoryTemplate.GetInventoryName(), inventoryTemplate.GetInventorySize(), inventoryTemplate.GetGold(), onInventoryItemChanged);
    }

    private void InitializeInventory(string _inventoryName, int _inventorySize, int _startGoldAmount, OnVariableChangeDelegate onInventoryItemChanged)
    {
        this.inventoryName = _inventoryName;
        this.inventorySize = _inventorySize;
        this.gold = _startGoldAmount;
        initializeInventorySlots(_inventorySize, onInventoryItemChanged);
    }

    private void initializeInventorySlots(int _inventorySize, OnVariableChangeDelegate onInventoryItemChanged)
    {
        inventorySlots = new List<InventorySlot>();
        for (int i = 0; i < _inventorySize; i++)
        {
            InventorySlot inventorySlot = new InventorySlot();
            if (onInventoryItemChanged != null)
            {
                inventorySlot.OnInventoryItemChanged += onInventoryItemChanged;
            }
            inventorySlots.Add(inventorySlot);
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
            firstEmptySlot.InventoryItem = inventoryObject;
            return true;
        }

        return false;
    }

    public void MoveItem(int from, int to)
    {
        InventoryObject invObjectToMove = this.inventorySlots[from].InventoryItem;
        this.inventorySlots[from].InventoryItem = null;
        to--;
        this.inventorySlots[to].InventoryItem = invObjectToMove;

        Debug.Log("Moved item from " + from + ", to " + to);
    }

    public void MoveItem(int from, int to, bool overrideDestinationItem)
    {
        to--;
        InventoryObject fromObject = this.inventorySlots[from].InventoryItem;
        InventoryObject destinationObject = overrideDestinationItem ? null : this.inventorySlots[to].InventoryItem;
        this.inventorySlots[from].InventoryItem = destinationObject;
        this.inventorySlots[to].InventoryItem = fromObject;

        Debug.Log("Switched items from " + from + ", to " + to);
    }

    public void RemoveItemAt(int from)
    {
        this.inventorySlots[from].InventoryItem = null;
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

    public void GiveGold(int amount)
    {
        this.gold += amount;
    }

    public int GoldCount
    {
        get
        {
            return this.gold;
        }
    }
}
