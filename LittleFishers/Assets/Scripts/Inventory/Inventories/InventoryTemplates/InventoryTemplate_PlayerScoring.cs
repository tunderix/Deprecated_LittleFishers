using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Player Scoring Inventory", menuName = "Inventory System v2/Inventories/Player Scoring Inventory")]
    public class InventoryTemplate_PlayerScoring : InventoryTemplate
    {
        [Header("Player Scoring Inventory Attributes")]
        [SerializeField] List<InventoryItemTemplate> defaultItemTemplates;
        public override List<InventoryItemTemplate> DefaultItemTemplates => defaultItemTemplates;
    }
}
