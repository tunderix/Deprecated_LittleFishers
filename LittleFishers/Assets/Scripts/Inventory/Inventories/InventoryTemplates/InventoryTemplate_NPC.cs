using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New NPC Inventory", menuName = "Inventory System v2/Inventories/NPC Inventory")]
    public class InventoryTemplate_NPC : InventoryTemplate
    {
        public override List<InventoryItem> DefaultItems()
        {
            return new List<InventoryItem>();
        }
    }
}
