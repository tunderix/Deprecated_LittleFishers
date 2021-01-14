using System.Collections.Generic;
using System.Linq;

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

        public Inventory()
        {
            _inventoryName = "";
            _inventorySize = 16;
            _gold = 0;

            CreateInventory();
        }

        public Inventory(InventoryTemplate template)
        {
            _inventoryName = template.InventoryName;
            _inventorySize = template.InventoryCapacity;
            _gold = template.Gold;

            CreateInventory();
        }

        private void CreateInventory()
        {
            Dictionary<InventorySlot, InventoryItemStack> newInventoryItems = new Dictionary<InventorySlot, InventoryItemStack>(_inventorySize);
            for (int i = 0; i < _inventorySize; i++)
            {
                newInventoryItems.Add(new InventorySlot(i), new InventoryItemStack(new InventoryItem(), 0));
            }
            _inventoryItems = newInventoryItems;
        }

        private InventorySlot firstFreeSlot
        {
            get
            {
                foreach (KeyValuePair<InventorySlot, InventoryItemStack> pair in _inventoryItems)
                {
                    if (pair.Value.ItemCount < 1 || pair.Value.IsEmpty)
                    {
                        return pair.Key;
                    }
                }
                return null;
            }
        }

        public Dictionary<InventorySlot, InventoryItemStack> GetInventoryItems()
        {
            return _inventoryItems;
        }

        public InventorySlot Slot(int at)
        {
            return _inventoryItems.Keys.ElementAt(at);
        }

        public InventoryItemStack GetItemStackAtSlot(InventorySlot slot)
        {
            InventoryItemStack itemStack = null;
            _inventoryItems.TryGetValue(slot, out itemStack);
            return itemStack;
        }

        public bool AddItem(InventoryItem item) // TODO - Return int / slotId instead of bool
        {
            InventorySlot to = firstFreeSlot;
            if (to == null) return false;
            InventoryItemStack _iStack = null;
            this._inventoryItems.TryGetValue(to, out _iStack);
            if (_iStack.IsEmpty) this._inventoryItems[to] = new InventoryItemStack(item, 1);
            else if (_iStack.Item == item) _iStack.ItemCount++;

            return true;
        }

        public bool RemoveItem(InventoryItem item)
        {
            foreach (KeyValuePair<InventorySlot, InventoryItemStack> pair in _inventoryItems)
            {
                if (InventoryItem.IsEqual(pair.Value.Item, item))
                {
                    pair.Value.RemoveOneItem();
                    return true;
                }
            }
            return false;
        }
    }
}