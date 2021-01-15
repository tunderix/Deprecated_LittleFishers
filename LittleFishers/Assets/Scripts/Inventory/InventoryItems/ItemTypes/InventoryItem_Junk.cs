using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    public class InventoryItem_Junk : InventoryItem
    {
        public InventoryItem_Junk(InventoryItemTemplate_Junk template) : base(template)
        {

        }

        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Junk;
        }
    }
}
