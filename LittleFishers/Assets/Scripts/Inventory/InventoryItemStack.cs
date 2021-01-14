namespace LittleFishers.LFInventory
{
    public class InventoryItemStack : IInventoryItemStack
    {
        private int _count;
        private InventoryItem _item;

        public InventoryItemStack()
        {
            _count = -1;
            _item = null;
        }

        public InventoryItemStack(InventoryItem item, int count)
        {
            _count = count;
            _item = item;
        }

        public int ItemCount { get => _count; set => _count = value; }
        public InventoryItem Item { get => _item; set => _item = value; }

        public void RemoveOneItem()
        {
            _count--;
            if (_count < 1) _item = null;
        }

        public bool IsEmpty
        {
            get => (_count < 1) || _item.IsDefault;
        }
    }
}
