using UnityEngine;

public class Hut : MonoBehaviour
{
    private Player _visitingPlayer;

    [SerializeField]
    private Inventory _hutInventory;

    [SerializeField]
    private GameObject ShopLayout;

    private InventorySystem _inventorySystem;

    [SerializeField]
    private InventoryTemplate defaultHutInventory;

    [SerializeField]
    private WeighingInventory _weighingInventory;

    [SerializeField]
    private Backpack backpack;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Approached Hut");
        ShopLayout.SetActive(true);

        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            _visitingPlayer = player;
        }
    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Left Hut");
        ShopLayout.SetActive(false);
        _visitingPlayer = null;
    }

    public void SetHutInventory(Inventory inventory)
    {
        this._hutInventory = inventory;
    }

    // Hooked in unity editor
    public void SellItemsInInventory()
    {
        if (this._hutInventory == null) return;

        int totalGoldAmount = 0;
        for (int i = 0; i < this._hutInventory.inventorySlots.Count; i++)
        {
            totalGoldAmount += SellInventoryItem(i);
        }
        if (_visitingPlayer != null)
        {
            _visitingPlayer.GetPlayerInventory().GiveGold(totalGoldAmount);
        }
        this.backpack.UpdateBackpack();
    }

    private int SellInventoryItem(int atIndex)
    {
        int goldValue = 0;
        InventorySlot slot = this._hutInventory.inventorySlots[atIndex];
        if (slot != null && slot.InventoryItem != null)
        {
            goldValue += slot.InventoryItem.goldValue;
        }

        this._hutInventory.RemoveItemAt(atIndex);
        this._weighingInventory.UpdateWeighingInventory();

        return goldValue;
    }

    public void InitializeHut(InventorySystem inventorySystem)
    {
        this._inventorySystem = inventorySystem;
        SetHutInventory(InventorySystem.CreateNewInventoryBasedOn(defaultHutInventory, InventoryItemWasChanged));
        _weighingInventory.InstantiateWeighingSlots(_hutInventory, OnBackpackItemDroppedOn);
    }

    private void OnBackpackItemDroppedOn(BackpackSlot from, BackpackSlot to)
    {
        if (_visitingPlayer != null)
        {
            _visitingPlayer.GetPlayerInventory().RemoveItemAt(from.backpackSlotId);
        }

        _hutInventory.AddItem(from.item);
        this._weighingInventory.UpdateWeighingInventory();
    }

    private void InventoryItemWasChanged()
    {
        this._weighingInventory.UpdateWeighingInventory();
        backpack.UpdateBackpack();
    }
}
