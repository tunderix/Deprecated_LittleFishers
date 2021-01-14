using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace LittleFishers.LFInventory
{
    public class inventory_item_stack
    {
        [Test]
        public void default_initialize_null()
        {
            InventoryItemStack stack = new InventoryItemStack();

            Assert.AreEqual(stack.Item, null);
            Assert.AreEqual(stack.ItemCount, -1);
        }

        [Test]
        public void default_initialize_empty_inventory()
        {
            InventoryItemStack stack = new InventoryItemStack(new InventoryItem(), 4);

            Assert.AreEqual(stack.Item.ItemName, "Empty Inventory");
        }
    }
}
