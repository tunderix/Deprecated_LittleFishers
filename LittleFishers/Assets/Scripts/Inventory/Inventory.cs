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
        }
        
        {
        After:
            public bool AddItem(InventoryItem 
            {
                */
            }
                {

                }

                }
                {
            }
        }