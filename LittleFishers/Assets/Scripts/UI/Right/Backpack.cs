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
    private Inventory playerInv;

    [SerializeField]
    private TextMeshProUGUI goldLabel;

    [SerializeField]
    private TextMeshProUGUI slotCountLabel;

    private int _slotsReserved;

    void Start()
    {
        _slotsReserved = 0;
        UpdateBackpack();
        UpdateGoldAmount(0);
    }

    public void UpdateBackpack()
    {
        ClearBackpack();

        for (int i = 0; i < playerInv.GetInventorySize(); i++)
        {
            GameObject newBackpackSlot = AddBackpackSlot(i);
        }

        UpdateSlotCount(playerInv.GetInventorySize());
    }

    private void ClearBackpack()
    {
        _slotsReserved = 0;
        foreach (Transform child in gridLayoutGroup.transform)
        {
            GameObject.Destroy(child.gameObject);
            // TODO -> Update UI. Maybe callback from playerInventory to Backpack
        }
    }

    private GameObject AddBackpackSlot(int i)
    {

        GameObject newBackpackSlot = GameObject.Instantiate(backpackSlotPrefab);
        newBackpackSlot.transform.SetParent(this.gridLayoutGroup.transform);

        if (i < playerInv.inventorySlots.Count())
        {
            ItemObject itemObject = playerInv.inventorySlots.ElementAt(i).GetInventoryItem();
            if (itemObject)
            {
                _slotsReserved += 1;
                newBackpackSlot.GetComponent<BackpackSlot>().SetItem(itemObject, playerInv.inventorySlots.ElementAt(i).GetAmount());
            }
        }

        return newBackpackSlot;
    }

    public void UpdateGoldAmount(int goldAmount)
    {
        goldLabel.SetText(goldAmount.ToString());
    }

    public void UpdateSlotCount(int slotCount)
    {
        slotCountLabel.SetText(_slotsReserved.ToString() + "/" + slotCount.ToString());
    }
}
