using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Fish", menuName = "Inventory System v2/Inventory Items/Fish")]
    public class InventoryItemTemplate_Fish : InventoryItemTemplate
    {
        public int Weight;
        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Fish;
        }
    }
}
