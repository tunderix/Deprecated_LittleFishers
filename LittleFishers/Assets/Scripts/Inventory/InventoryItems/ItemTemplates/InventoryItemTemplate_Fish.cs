using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Fish", menuName = "Inventory System v2/Inventory Items/Fish")]
    public class InventoryItemTemplate_Fish : InventoryItemTemplate
    {
        [Header("Fish Specific Attributes")]
        public int MinWeight;
        public int MaxWeight;
        public int MinStrength;
        public int MaxStrength;
        public int MinExperienceGain;
        public int MaxExperienceGain;

        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Fish;
        }
    }
}
