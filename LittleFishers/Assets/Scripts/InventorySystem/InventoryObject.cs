using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryObject
{
    public string itemName;
    public string description;
    public int goldValue;
    public int amount;
    public Sprite inventoryIcon;

    public InventoryObject()
    {
        this.itemName = "";
        this.description = "";
        this.goldValue = 0;
        this.amount = 0;
        this.inventoryIcon = null;
    }

    public InventoryObject(string itemName, string description, int goldValue, int amount, Sprite inventoryIcon)
    {
        this.itemName = itemName;
        this.description = description;
        this.goldValue = goldValue;
        this.amount = amount;
        this.inventoryIcon = inventoryIcon;
    }

    public InventoryObject(Fish fish)
    {
        this.itemName = fish.FishName;
        this.description = fish.Description;
        this.goldValue = fish.GoldValue;
        this.amount = 1;
        this.inventoryIcon = fish.FishIcon;
    }

    public InventoryObject(ItemObject itemObject)
    {
        this.itemName = itemObject.itemName;
        this.description = itemObject.description;
        this.goldValue = itemObject.minGoldValue;
        this.amount = 1;
        this.inventoryIcon = itemObject.backpackIcon;
    }

    public bool IsEmpty
    {
        get
        {
            if (itemName == "(null)" || itemName == null) return true;
            return itemName == "";
        }
    }
}
