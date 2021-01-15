using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Tome", menuName = "Inventory System v2/Inventory Items/Tome")]
    public class InventoryItemTemplate_Tome : InventoryItemTemplate
    {
        public TomeType TomeModifier;

        public override InventoryItemType GetItemType()
        {
            return InventoryItemType.Tome;
        }
    }
}
