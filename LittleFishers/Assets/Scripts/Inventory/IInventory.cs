using System.Collections.Generic;

namespace LittleFishers.LFInventory
{
    public interface IInventory
    {
        string InventoryName { get; set; }
        int InventorySize { get; set; }
        int Gold { get; set; }

        public bool AddItem(InventoryItem item);
        public bool RemoveItem(InventoryItem item);
    }
}