using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    public class InventoryItem_Fish : InventoryItem
    {
        private int _weight;

        public InventoryItem_Fish(InventoryItemTemplate_Fish template) : base(template)
        {
            _weight = template.Weight;
        }

        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Fish;
        }

        public int Weight { get => _weight; }
    }
}
