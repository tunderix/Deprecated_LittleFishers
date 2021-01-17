using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace LittleFishers.LFInventory
{
    public class inventory
    {
        private readonly IInventory _inventory = Substitute.For<IInventory>();

        private Dictionary<InventorySlot, InventoryItemStack> emptyInventory { get => new Dictionary<InventorySlot, InventoryItemStack>(4); }

        [Test]
        public void inventory_doesnt_have_content_at_start()
        {
            _inventory.GetInventoryItems().Returns(emptyInventory);

            Assert.AreEqual(0, _inventory.GetInventoryItems().Values.Count);
            Assert.AreEqual(0, _inventory.GetInventoryItems().Keys.Count);
        }

        [Test]
        public void get_inventory_items_returns_correct_amount_of_items()
        {
            Dictionary<InventorySlot, InventoryItemStack> invWithItems = emptyInventory;
            invWithItems.Add(new InventorySlot(0), new InventoryItemStack());
            invWithItems.Add(new InventorySlot(1), new InventoryItemStack());
            invWithItems.Add(new InventorySlot(2), new InventoryItemStack());
            _inventory.GetInventoryItems().Returns(invWithItems);

            Assert.AreEqual(3, _inventory.GetInventoryItems().Values.Count);
            Assert.AreEqual(3, _inventory.GetInventoryItems().Keys.Count);
        }

        [Test]
        public void get_correct_item_count_at_specific_slot()
        {
            InventorySlot slot = new InventorySlot(0);
            _inventory.GetItemStackAtSlot(slot).Returns(new InventoryItemStack(new InventoryItem(), 3));

            Assert.AreEqual(3, _inventory.GetItemStackAtSlot(slot).ItemCount);
        }

        [Test]
        public void get_correct_item_at_specific_slot()
        {
            InventorySlot slot = new InventorySlot(0);
            _inventory.GetItemStackAtSlot(slot).Returns(new InventoryItemStack(new InventoryItem(), 3));

            Assert.AreEqual("Empty Inventory Item", _inventory.GetItemStackAtSlot(slot).FirstItem.ItemName);
        }

        [Test]
        public void add_item_to_inventory()
        {
            /*IInventory addTestInventory = new Inventory();
            InventorySlot aSlot = addTestInventory.Slot(0);

            Assert.AreEqual(0, addTestInventory.GetItemStackAtSlot(aSlot).ItemCount);

            addTestInventory.AddItem(new InventoryItem());
            Assert.AreEqual(1, addTestInventory.GetItemStackAtSlot(aSlot).ItemCount);
*/
        }

        [Test]
        public void remove_default_item()
        {
            /*
            IInventory removeTestInventory = new Inventory();
            InventorySlot aSlot = removeTestInventory.Slot(0);
            InventoryItem _item = new InventoryItem();

            removeTestInventory.AddItem(_item);
            Assert.AreEqual(1, removeTestInventory.GetItemStackAtSlot(aSlot).ItemCount);

            removeTestInventory.RemoveItem(_item);
            Assert.AreEqual(0, removeTestInventory.GetItemStackAtSlot(aSlot).ItemCount);
*/
        }
    }
}