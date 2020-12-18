using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Backpack : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup gridLayoutGroup;

    [SerializeField]
    private GameObject backpackSlotPrefab;

    [SerializeField]
    private GameObject draggableArea;

    [SerializeField]
    private GameObject backpackInventoryItemPrefab;

    [SerializeField]
    private Inventory localPlayerInventory;

    [SerializeField]
    private TextMeshProUGUI goldLabel;

    [SerializeField]
    private TextMeshProUGUI slotCountLabel;

    void Start()
    {
        UpdateBackpack();
    }

    public void SetLocalPlayerInventory(Inventory inventory)
    {
        this.localPlayerInventory = inventory;
    }

    public void UpdateBackpack()
    {
        if (localPlayerInventory == null) return;

        ClearBackpack();

        foreach (InventorySlot slot in localPlayerInventory.inventorySlots)
        {
            BackpackSlot newBackpackSlot = AddBackpackSlot(slot);
            newBackpackSlot.item = slot.InventoryItem;
            if (!slot.IsEmpty)
            {
                BackpackInventoryItem newItem = InstantiateBackpackInventoryItem(slot.InventoryItem);
                newItem.SetPositionTo(newBackpackSlot);
            }
        }

        UpdateGoldAmount();
        UpdateSlotCount();
    }

    private BackpackInventoryItem InstantiateBackpackInventoryItem(InventoryObject inventoryObject)
    {
        GameObject newItem = GameObject.Instantiate(backpackInventoryItemPrefab);
        BackpackInventoryItem bii = newItem.GetComponent<BackpackInventoryItem>();
        bii.transform.SetParent(draggableArea.transform);
        bii.SetImage(inventoryObject.inventoryIcon);
        return bii;
    }

    public void ClearBackpack()
    {
        LittleFishersHelpers.DestroyAllChilds(gridLayoutGroup.transform);
        LittleFishersHelpers.DestroyAllChilds(draggableArea.transform);
    }

    private BackpackSlot AddBackpackSlot(InventorySlot slot)
    {

        GameObject newBackpackSlot = GameObject.Instantiate(backpackSlotPrefab);
        newBackpackSlot.transform.SetParent(this.gridLayoutGroup.transform);
        BackpackSlot backpackSlot = newBackpackSlot.GetComponent<BackpackSlot>();
        return backpackSlot;
    }

    public void UpdateSlotCount()
    {
        slotCountLabel.SetText(localPlayerInventory.GetReservedSlots().ToString() + "/" + localPlayerInventory.SlotCount.ToString());
    }

    public void UpdateGoldAmount()
    {
        goldLabel.SetText(localPlayerInventory.GoldCount.ToString());
    }
}
