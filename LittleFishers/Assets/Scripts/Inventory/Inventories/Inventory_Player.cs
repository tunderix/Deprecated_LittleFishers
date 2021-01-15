using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    public class Inventory_Player : Inventory
    {
        public Inventory_Player(InventoryTemplate_Player template) : base(template)
        {
            AddItems(template.DefaultItems());
        }
    }
}
