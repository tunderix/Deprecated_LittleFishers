using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Goes through all different Inventory Item Objects and transforms them into real inventory items
public class InventoryObjectFactory
{
    public InventoryObjectFactory()
    {

    }

    public InventoryObject CreateNewInventoryObject(ItemObject itemObject)
    {
        return new InventoryObject(itemObject);
    }
}
