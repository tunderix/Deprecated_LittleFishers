using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Weighing Inventory", menuName = "Inventory System v2/Inventories/Weighing Inventory")]
    public class InventoryTemplate_Weighing : InventoryTemplate
    {
        public override List<InventoryItem> DefaultItems()
        {
            return new List<InventoryItem>();
        }
    }
}
