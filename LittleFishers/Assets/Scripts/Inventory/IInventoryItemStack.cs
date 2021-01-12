namespace LittleFishers.LFInventory
{
    public interface IInventoryItemStack
    {
        int ItemCount { get; set; }
        InventoryItem Item { get; set; }
    }
}