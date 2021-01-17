using UnityEngine;
using LittleFishers.LFInventory;
using TMPro;

namespace LittleFishers.UI
{
    public class UI_ShopLayout : MonoBehaviour
    {
        [SerializeField] private UI_ShoppingLayout shoppingLayout;
        [SerializeField] private UI_WeighingLayout weighingLayout;
        [SerializeField] private TextMeshProUGUI titleLabel;

        public void UpdateContents(Inventory_Shop shop, Inventory_Weighing weighing)
        {
            titleLabel.text = shop.InventoryName;
            if (shop != null)
            {
                shoppingLayout.ShowInventory(shop);
            }
            if (weighing != null)
            {
                weighingLayout.ShowInventory(weighing);
            }
        }
    }
}
