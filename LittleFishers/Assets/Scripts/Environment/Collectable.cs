using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private ItemObject inventoryItem;

    [SerializeField]
    private int inventoryItemCount;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerSelf") return;

        Player player = other.GetComponent<Player>();
        InventoryObject newInventoryObject = new InventoryObject(inventoryItem);
        bool collectedCollectable = player.GetPlayerInventory().AddItem(newInventoryObject);
        if (collectedCollectable)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Player Backpack Full, Cannot collect.");
        }
    }
}
