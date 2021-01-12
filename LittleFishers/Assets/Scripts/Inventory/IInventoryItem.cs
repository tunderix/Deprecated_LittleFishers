using UnityEngine;
namespace LittleFishers.LFInventory
{
    public interface IInventoryItem
    {
        string ItemName { get; set; }
        string Description { get; set; }
        int GoldValue { get; set; }
        Sprite InventoryIcon { get; set; }
        int MaxStackSize { get; set; }
    }
}