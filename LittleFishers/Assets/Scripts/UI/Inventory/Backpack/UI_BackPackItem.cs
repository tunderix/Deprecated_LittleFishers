using UnityEngine.UI;
using UnityEngine;
using TMPro;
using LittleFishers.LFInventory;

namespace LittleFishers.UI
{
    public class UI_BackPackItem : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;
        public void SetContent(InventoryItemStack stack)
        {
            itemIcon.sprite = stack.FirstItem.InventoryIcon;
        }
    }
}