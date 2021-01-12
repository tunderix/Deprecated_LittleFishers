namespace LittleFishers.LFInventory
{
    public class InventoryItemStack
    {
        private int _count;
        private InventoryItem _item;

        public InventoryItemStack()
        {
            _count = 0;
            _item = null;
        }

        public int ItemCount { get => _count; set => _count = value; }
        public InventoryItem Item { get => _item; set => _item = value; }
    }
}
