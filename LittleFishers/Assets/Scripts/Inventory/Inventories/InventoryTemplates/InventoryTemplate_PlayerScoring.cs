using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Player Scoring Inventory", menuName = "Inventory System v2/Inventories/Player Scoring Inventory")]
    public class InventoryTemplate_PlayerScoring : InventoryTemplate
    {
        public override List<InventoryItem> DefaultItems()
        {
            return new List<InventoryItem>();
        }
    }
}
