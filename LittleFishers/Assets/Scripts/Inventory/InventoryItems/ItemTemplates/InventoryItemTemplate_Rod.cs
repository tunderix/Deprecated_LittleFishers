using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Rod", menuName = "Inventory System v2/Inventory Items/Rod")]
    public class InventoryItemTemplate_Rod : InventoryItemTemplate
    {
        [Header("Rod Specific Attributes")]
        public int StrengthModifier;
        public int AttractionModifier;
        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Rod;
        }
    }
}
