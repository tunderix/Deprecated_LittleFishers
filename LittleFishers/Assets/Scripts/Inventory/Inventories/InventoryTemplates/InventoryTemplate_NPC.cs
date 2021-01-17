using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New NPC Inventory", menuName = "Inventory System v2/Inventories/NPC Inventory")]
    public class InventoryTemplate_NPC : InventoryTemplate
    {
        [Header("NPC Inventory Attributes")]
        [SerializeField] private List<InventoryItemTemplate> defaultItemTemplates;
        public override List<InventoryItemTemplate> DefaultItemTemplates => defaultItemTemplates;
    }
}
