using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            InitializeInventoryItems();
            CreateInventory(template.DefaultItemTemplates);
        }

        private void InitializeInventoryItems()
        {
            _inventoryItems = new Dictionary<InventorySlot, InventoryItemStack>(_inventorySize);
            for (int i = 0; i < _inventorySize; i++)
            {
                _inventoryItems.Add(new InventorySlot(i), new InventoryItemStack());
            }
        }

        private void CreateInventory(List<InventoryItemTemplate> templates)
        {
            foreach (InventoryItemTemplate iTemplate in templates)
            {
                InventoryItem item = new InventoryItem(iTemplate);
                AddItem(item);
            }
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

        public bool AddItem(InventoryItem item)
        {
            InventorySlot to = firstFreeSlot;
            if (to == null) return false;
            InventoryItemStack _iStack = null;
            this._inventoryItems.TryGetValue(to, out _iStack);
            if (_iStack.FirstItem == null) return false;
            if (item.StacksWith(_iStack.FirstItem)) _iStack.AddItem(item);
            else if (_iStack.IsEmpty) this._inventoryItems[to] = new InventoryItemStack(item, 1);
            Debug.Log("Added item to inventory: " + item.ItemName);
            return true;
        }

        public bool AddItems(List<InventoryItem> items)
        {
            bool allItemsAdded = true;
            foreach (InventoryItem item in items)
            {
                bool success = AddItem(item);
                if (!success) allItemsAdded = false;
            }
            return allItemsAdded;
        }

        public bool RemoveItem(InventoryItem item)
        {
            foreach (KeyValuePair<InventorySlot, InventoryItemStack> pair in _inventoryItems)
            {
                if (pair.Value.Contains(item))
                {
                    pair.Value.RemoveItem(item);
                    return true;
                }
            }
            return false;
        }
    }
}