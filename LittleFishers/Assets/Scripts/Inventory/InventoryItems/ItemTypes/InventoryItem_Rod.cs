using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    public class InventoryItem_Rod : InventoryItem
    {
        private int _strengthModifier;
        private int _attractionModifier;

        public InventoryItem_Rod(InventoryItemTemplate_Rod template) : base(template)
        {
            _attractionModifier = template.AttractionModifier;
            _strengthModifier = template.StrengthModifier;
        }

        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Rod;
        }

        public int StrengthModifier { get => _strengthModifier; }
        public int AttractionModifier { get => _attractionModifier; }
    }
}
