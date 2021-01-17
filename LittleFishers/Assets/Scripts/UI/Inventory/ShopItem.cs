using UnityEngine;
using LittleFishers.LFInventory;
using TMPro;
using UnityEngine.UI;

namespace LittleFishers.UI
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemNameLabel;
        [SerializeField] private TextMeshProUGUI itemCountLabel;
        [SerializeField] private TextMeshProUGUI itemCostLabel;
        [SerializeField] private Image itemIcon;

        public void SetContent(InventoryItemStack itemStack)
        {
            itemNameLabel.text = itemStack.FirstItem.ItemName;
            itemCountLabel.text = itemStack.ItemCount.ToString();
            itemCostLabel.text = itemStack.FirstItem.GoldValue.ToString(); //TODO - Should be current selected item, not first
            itemIcon.sprite = itemStack.FirstItem.InventoryIcon;
        }
    }
}
