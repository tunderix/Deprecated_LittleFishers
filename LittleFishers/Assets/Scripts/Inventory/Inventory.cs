using System.Collections.Generic;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    public class Inventory : IInventory
    {
        private string _inventoryName;
        private int _inventorySize;
        private int _gold;
        private Dictionary<InventorySlot, InventoryItemStack> _inventoryItems;

        public string InventoryName { get => _inventoryName; set => _inventoryName = value; }
        public int InventorySize { get => _inventorySize; set => _inventorySize = value; }
        public int Gold { get => _gold; set => _gold = value; }

        public Inventory(InventoryTemplate template)
        {
            _inventoryName = template.InventoryName;
            _inventorySize = template.InventoryCapacity;
            _gold = template.Gold;

            InititializeInventorySlots(template.InventoryCapacity);
        }

        private void InititializeInventorySlots(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                _inventoryItems.Add(new InventorySlot(i), new InventoryItemStack());
            }
        }

        private InventorySlot firstFreeSlot
        {
            get
            {
                foreach (KeyValuePair<InventorySlot, InventoryItemStack> pair in _inventoryItems)
                {
                    if (pair.Value.ItemCount < 1)
                    {
                        return pair.Key;
                    }
                }
                return null;
            }
        }

        public bool AddItem(InventoryItem item)
        {
            InventorySlot to = firstFreeSlot;
            if (to == null) return false;
            this._inventoryItems.Add(to, new InventoryItemStack(item, 1));
            return true;
        }

        public bool RemoveItem(InventoryItem item)
        {
            foreach (KeyValuePair<InventorySlot, InventoryItemStack> pair in _inventoryItems)
            {
                if (pair.Value.Item == item)
                {
                    pair.Value.RemoveOneItem();
                    return true;
                }
            }
            return false;
        }
    }
}