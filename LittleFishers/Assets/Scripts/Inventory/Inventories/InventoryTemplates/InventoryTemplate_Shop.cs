using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Shop Inventory", menuName = "Inventory System v2/Inventories/Shop Inventory")]
    public class InventoryTemplate_Shop : InventoryTemplate
    {
        [Header("Shop Inventory Attributes")]
        [SerializeField] List<InventoryItemTemplate> defaultItemTemplates;
        public override List<InventoryItemTemplate> DefaultItemTemplates => defaultItemTemplates;
    }
}
