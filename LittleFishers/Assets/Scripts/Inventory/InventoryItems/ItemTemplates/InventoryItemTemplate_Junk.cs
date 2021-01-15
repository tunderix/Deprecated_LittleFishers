using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Junk", menuName = "Inventory System v2/Inventory Items/Fish")]
    public class InventoryItemTemplate_Junk : InventoryItemTemplate
    {
        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Junk;
        }
    }
}
