using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeighingInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject weighingSlotPrefab;

    private Inventory _inventory;
    private BackpackItemDroppedDelegate _onBackpackItemDroppedOn;
    void Start()
    {

    }

    public void InstantiateWeighingSlots(Inventory inventory, BackpackItemDroppedDelegate onBackpackItemDroppedOn)
    {
        this._inventory = inventory;
        this._onBackpackItemDroppedOn = onBackpackItemDroppedOn;

        UpdateWeighingInventory();
    }

    public void UpdateWeighingInventory()
    {
        if (this._inventory == null) return;

        LittleFishersHelpers.DestroyAllChilds(this.transform);

        for (int i = 0; i < this._inventory.inventorySlots.Count; i++)
        {
            GameObject slot = GameObject.Instantiate(weighingSlotPrefab, weighingSlotPrefab.transform.position, Quaternion.identity);
            slot.transform.SetParent(this.transform);
            WeighingSlot weighingSlot = slot.GetComponent<WeighingSlot>();
            if (weighingSlot != null)
            {
                weighingSlot.slotIndex = i;
                weighingSlot.item = this._inventory.inventorySlots[i].InventoryItem;
                weighingSlot.SetImage();
            }

            DropSlot dropSlot = slot.GetComponent<DropSlot>();
            if (dropSlot != null)
            {
                dropSlot.OnBackpackItemDroppedOn += _onBackpackItemDroppedOn;
            }
        }
    }
}
