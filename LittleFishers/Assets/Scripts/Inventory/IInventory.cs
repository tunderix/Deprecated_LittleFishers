using System.Collections.Generic;

namespace LittleFishers.LFInventory
{
    public interface IInventory
    {
        string InventoryName { get; set; }
        int InventorySize { get; set; }
        int Gold { get; set; }

        public Dictionary<InventorySlot, InventoryItemStack> GetInventoryItems();
        public InventorySlot Slot(int at);
        public InventoryItemStack GetItemStackAtSlot(InventorySlot slot);
        public bool AddItem(InventoryItem item);
        public bool RemoveItem(InventoryItem item);
    }
}