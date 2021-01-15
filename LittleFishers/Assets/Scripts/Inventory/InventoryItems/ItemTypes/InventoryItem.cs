
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    public class InventoryItem : IInventoryItem
    {
        private string _itemName;
        private string _description;
        private int _goldValue;
        private Sprite _inventoryIcon;
        private int _maxStackSize;
        private InventoryItemType _itemType;

        public InventoryItem()
        {
            _itemName = "Empty Inventory Item";
            _description = "NAN";
            _goldValue = -1;
            _inventoryIcon = null;
            _maxStackSize = 1;
            _itemType = InventoryItemType.Default;
        }

        public InventoryItem(InventoryItemTemplate template)
        {
            _itemName = template.ItemName;
            _description = template.Description;
            _goldValue = template.MinGoldValue; // Instead generate the gold value somehow
            _inventoryIcon = template.InventoryIcon;
            _maxStackSize = template.MaxStackSize;
            _itemType = template.GetItemType();
        }

        public bool IsDefault
        {
            get => _itemName == "Empty Inventory Item";
        }

        public bool StacksWith(InventoryItem item)
        {
            return _itemName == item._itemName; //TODO - Stacking by item subtype instead of name.... 
        }

        public static bool IsEqual(InventoryItem item1, InventoryItem item2)
        {
            return item1._itemName == item2._itemName && item1._goldValue == item2._goldValue; // TODO fix this with better
        }

        public virtual InventoryItemType GetItemType()
        {
            return InventoryItemType.Default;
        }

        public string ItemName { get => _itemName; set => _itemName = value; }
        public string Description { get => _description; set => _description = value; }
        public int GoldValue { get => _goldValue; set => _goldValue = value; }
        public Sprite InventoryIcon { get => _inventoryIcon; set => _inventoryIcon = value; }
        public int MaxStackSize { get => _maxStackSize; set => _maxStackSize = value; }
    }
}