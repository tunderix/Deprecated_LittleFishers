using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    public class InventoryItem_Tome : InventoryItem
    {
        private TomeType _tomeType;

        public InventoryItem_Tome(InventoryItemTemplate_Tome template) : base(template)
        {
            _tomeType = template.TomeModifier;
        }

        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Tome;
        }

        public TomeType TomeType { get => _tomeType; }
    }
}
