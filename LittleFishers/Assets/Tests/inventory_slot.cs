using NUnit.Framework;
using NSubstitute;

namespace LittleFishers.LFInventory
{
    public class inventory_slot
    {
        [Test]
        public void has_id()
        {
            InventorySlot slot = Substitute.For<InventorySlot>(3);

            Assert.AreEqual(slot.SlotID, 3);
        }
    }
}