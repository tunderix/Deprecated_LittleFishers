using UnityEngine;
using LittleFishers.LFInventory;
using UnityEngine.UI;
using System.Collections.Generic;

namespace LittleFishers.UI
{
    public class UI_ShoppingLayout : MonoBehaviour
    {
        [SerializeField] private VerticalLayoutGroup layoutGroup;
        [SerializeField] private ShopItem shopItemPrefab;

        public void ShowInventory(Inventory_Shop inventoryToShow)
        {
            // First clear all components under layoutgroup
            LittleFishersHelpers.DestroyAllChilds(layoutGroup.transform);

            // Detect inventory items and make a shopitem prefab for each while setting parent to layout
            foreach (KeyValuePair<LittleFishers.LFInventory.InventorySlot, InventoryItemStack> pair in inventoryToShow.GetInventoryItems())
            {
                if (pair.Value.FirstItem.IsDefault) continue;
                ShopItem shopItem = (ShopItem)Instantiate(shopItemPrefab);
                shopItem.transform.parent = layoutGroup.transform;
                shopItem.SetContent(pair.Value);
            }

        }
    }
}
