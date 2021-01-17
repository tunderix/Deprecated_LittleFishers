using LittleFishers.LFInventory;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

namespace LittleFishers.UI
{
    public class UI_Backpack : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI slotsLabel;
        [SerializeField] private TextMeshProUGUI goldLabel;

        [SerializeField] private GridLayoutGroup layoutGroup;
        [SerializeField] private UI_BackpackSlot backpackSlotPrefab;
        [SerializeField] private UI_BackPackItem backpackItemPrefab;

        public void ShowInventory(Inventory_Player inventoryToShow)
        {
            // First clear all components under layoutgroup
            LittleFishersHelpers.DestroyAllChilds(layoutGroup.transform);

            // Detect inventory items and make a shopitem prefab for each while setting parent to layout
            foreach (KeyValuePair<LittleFishers.LFInventory.InventorySlot, InventoryItemStack> pair in inventoryToShow.GetInventoryItems())
            {
                UI_BackpackSlot slot = (UI_BackpackSlot)Instantiate(backpackSlotPrefab);
                slot.transform.SetParent(layoutGroup.transform);

                if (pair.Value.FirstItem.IsDefault) continue;
                UI_BackPackItem backpackItem = (UI_BackPackItem)Instantiate(backpackItemPrefab);
                backpackItem.transform.SetParent(slot.transform);
                backpackItem.SetContent(pair.Value);
            }

        }
    }
}
