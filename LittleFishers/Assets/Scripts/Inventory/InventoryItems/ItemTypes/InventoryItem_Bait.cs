using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    public class InventoryItem_Bait : InventoryItem
    {
        private int _useCount;
        private int _attractionModifier;
        private int _strengthModifier;

        public InventoryItem_Bait(InventoryItemTemplate_Bait template) : base(template)
        {
            this._useCount = template.UseCount;
            this._attractionModifier = template.AttractionModifier;
            this._strengthModifier = template.StrengthModifier;
        }

        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Bait;
        }

        public int AttractionModifier { get => _attractionModifier; }
        public int StrengthModifier { get => _strengthModifier; }
        public int UseCount { get => _useCount; }
    }
}
