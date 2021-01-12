using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class inventory
{
    [Test]
    public void inventory_has_16_slots()
    {
        Inventory inventory = new Inventory();
        inventory.AddItem(new InventoryObject());
        Assert.AreEqual(inventory.SlotCount, 16);
    }
}
