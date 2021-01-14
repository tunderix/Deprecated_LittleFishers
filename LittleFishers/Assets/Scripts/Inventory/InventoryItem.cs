
using UnityEngine;

namespace LittleFishers.LFInventory
{
    public class InventoryItem : IInventoryItem
    {
        private string _itemName;
        private string _description;
        private int _goldValue;
        private Sprite _inventoryIcon;
        private int _maxStackSize;

        public InventoryItem()
        {
            _itemName = "Empty Inventory Item";
            _description = "NAN";
            _goldValue = -1;
            _inventoryIcon = null;
            _maxStackSize = 1;
        }

        public InventoryItem(InventoryItemTemplate template)
        {
            _itemName = template.ItemName;
            _description = template.Description;
            _goldValue = template.GoldValue;
            _inventoryIcon = template.InventoryIcon;
            _maxStackSize = template.MaxStackSize;
        }

        public bool IsDefault
        {
            get => _itemName == "Empty Inventory Item";
        }

        public static bool IsEqual(InventoryItem item1, InventoryItem item2)
        {
            return item1._itemName == item2._itemName && item1._goldValue == item2._goldValue; // TODO fix this with better
        }

        public string ItemName { get => _itemName; set => _itemName = value; }
        public string Description { get => _description; set => _description = value; }
        public int GoldValue { get => _goldValue; set => _goldValue = value; }
        public Sprite InventoryIcon { get => _inventoryIcon; set => _inventoryIcon = value; }
        public int MaxStackSize { get => _maxStackSize; set => _maxStackSize = value; }
    }
}