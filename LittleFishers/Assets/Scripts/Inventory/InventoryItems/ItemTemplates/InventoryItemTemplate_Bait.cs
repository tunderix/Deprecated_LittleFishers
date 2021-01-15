using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Bait", menuName = "Inventory System v2/Inventory Items/Bait")]
    public class InventoryItemTemplate_Bait : InventoryItemTemplate
    {
        public int UseCount;
        public int AttractionModifier;
        public int StrengthModifier;
        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Bait;
        }
    }
}
