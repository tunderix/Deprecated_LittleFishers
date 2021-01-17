using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Player Inventory", menuName = "Inventory System v2/Inventories/Player Inventory")]
    public class InventoryTemplate_Player : InventoryTemplate
    {
        [Header("Player Inventory Attributes")]
        [SerializeField] private List<InventoryItemTemplate> defaultItemTemplates;
        public override List<InventoryItemTemplate> DefaultItemTemplates => defaultItemTemplates;
    }
}
