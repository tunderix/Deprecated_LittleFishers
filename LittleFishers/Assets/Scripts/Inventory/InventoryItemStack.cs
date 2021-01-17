using System.Collections.Generic;
using System.Linq;

namespace LittleFishers.LFInventory
{
    public class InventoryItemStack : IInventoryItemStack
    {
        private List<InventoryItem> _items;

        public InventoryItemStack()
        {
            _items = new List<InventoryItem>();
        }

        public InventoryItemStack(InventoryItem item, int count)
        {
            _items = new List<InventoryItem>();
            _items.Add(item);
        }

        public InventoryItemStack(List<InventoryItem> items, int count)
        {
            _items = items;
        }

        public int ItemCount { get => _items.Count; }
        public InventoryItem FirstItem { get => _items.Count > 0 ? _items.First() : new InventoryItem(); }
        public InventoryItem Item(int at)
        {
            return _items.ElementAtOrDefault(at);
        }

        public bool Contains(InventoryItem item)
        {
            return _items.Contains(item);
        }

        public bool AddItem(InventoryItem item)
        {
            if (_items.Count < StackSize)
            {
                _items.Add(item);
                return true;
            }
            return false;
        }

        public bool RemoveItem(InventoryItem item)
        {
            InventoryItem toBeRemoved = _items.Find(_item => _item.Equals(item));
            if (toBeRemoved != null)
            {
                _items.Remove(toBeRemoved);
                return true;
            }
            return false;
        }

        public int StackSize { get => FirstItem.MaxStackSize; }

        public bool IsEmpty
        {
            get => _items.Count < 1;
        }
    }
}
