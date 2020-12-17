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
        }

        UpdateSlotCount();
    }

    private void ClearBackpack()
    {
        foreach (Transform child in gridLayoutGroup.transform)
        {
            GameObject.Destroy(child.gameObject);
            // TODO -> Update UI. Maybe callback from playerInventory to Backpack
        }
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
}
