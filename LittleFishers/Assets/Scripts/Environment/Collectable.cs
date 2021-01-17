using UnityEngine;
using LittleFishers.LFInventory;

namespace LittleFishers.Environment
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private InventoryItemTemplate inventoryItemTemplate;

        public void OnTriggerEnter(Collider other)
        {
            Collector collector = other.GetComponent<Collector>();
            if (collector != null)
            {
                collector.Collected(new InventoryItem(inventoryItemTemplate));
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}