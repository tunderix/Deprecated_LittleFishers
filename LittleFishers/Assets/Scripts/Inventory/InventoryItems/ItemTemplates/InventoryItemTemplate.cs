using System.Collections.Generic;
using UnityEngine;
namespace LittleFishers.LFInventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System v2/Inventory Items/Default Item")]
    public class InventoryItemTemplate : ScriptableObject
    {
        [Header("Global Attributes")]
        public string ItemName;
        [TextArea(15, 20)]
        public string Description;
        public int MinGoldValue;
        public int MaxGoldValue;
        public Sprite InventoryIcon;
        public int MaxStackSize;

        public virtual InventoryItemType GetItemType()
        {
            return InventoryItemType.Default;
        }
    }
}