using UnityEngine;
using LittleFishers.LFInventory;

namespace LittleFishers.Environment
{
    public class Collector : MonoBehaviour
    {
        public delegate void CollectorCollected(InventoryItem inventoryItem);
        public CollectorCollected OnCollected;

        public void Collected(InventoryItem inventoryItem)
        {
            OnCollected(inventoryItem);
        }
    }
}
