using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Weighing Inventory", menuName = "Inventory System v2/Inventories/Weighing Inventory")]
    public class InventoryTemplate_Weighing : InventoryTemplate
    {
        [Header("Weighing Inventory Attributes")]
        [SerializeField] private List<InventoryItemTemplate> defaultItemTemplates;
        public override List<InventoryItemTemplate> DefaultItemTemplates => defaultItemTemplates;
    }
}
