using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Backpack : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup gridLayoutGroup;

    [SerializeField]
    private GameObject backpackSlotPrefab;

    [SerializeField]
    private Inventory playerInv;

    void Start()
    {
        UpdateBackpack();
    }

    public void UpdateBackpack()
    {
        ClearBackpack();
        for (int i = 0; i < playerInv.GetInventorySize(); i++)
        {
            GameObject newBackpackSlot = AddBackpackSlot(i);
        }
    }

    private void ClearBackpack()
    {
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
            newBackpackSlot.GetComponent<BackpackSlot>().SetItem(itemObject, playerInv.inventorySlots.ElementAt(i).GetAmount());
        }

        return newBackpackSlot;
    }
}
