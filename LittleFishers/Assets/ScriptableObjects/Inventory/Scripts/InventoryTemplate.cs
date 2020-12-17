using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryTemplate : ScriptableObject
{
    [SerializeField]
    private string inventoryName;

    [SerializeField]
    private int inventorySize;

    [SerializeField]
    private List<InventoryObject> backpackItems;

    [SerializeField]
    private int startGold;

    public string GetInventoryName()
    {
        return this.inventoryName;
    }

    public int GetInventorySize()
    {
        return this.inventorySize;
    }
}
