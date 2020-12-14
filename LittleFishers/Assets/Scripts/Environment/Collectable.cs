using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private ItemObject inventoryItem;

    [SerializeField]
    private Inventory playerInventory;

    [SerializeField]
    private int inventoryItemCount;

    public void OnTriggerEnter(Collider other)
    {
        bool collectedCollectable = playerInventory.AddItem(inventoryItem, inventoryItemCount);
        if (collectedCollectable)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
