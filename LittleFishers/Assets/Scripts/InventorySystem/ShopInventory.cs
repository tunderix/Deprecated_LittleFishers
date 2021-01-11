using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopInventory : Inventory
{
    [SerializeField] private InventoryTemplate itemTemplate;

    public ShopInventory()
    {
        base.InitializeInventory("Equipment On Sale", 8, 0, null);
    }

    public void SelectItem(int at)
    {

    }
}
