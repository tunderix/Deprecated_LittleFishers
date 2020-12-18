using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private List<PlayerGameState> playerStatusList;

    [SerializeField]
    private InventorySystem inventorySystem;
    [SerializeField]
    private InventoryTemplate defaultPlayerInventoryTemplate;

    [Header("UI Bindings")]
    [SerializeField]
    private PlayerList playerListComponent;
    [SerializeField]
    private Backpack UIBackPackComponent;

    private void Awake()
    {
        this.playerStatusList = new List<PlayerGameState>();
    }

    public void AddPlayerToStateListing(PlayerGameState playerState)
    {
        playerStatusList.Add(playerState);
        UpdatePlayerListComponent();
    }

    public void RemovePlayerFromStateListing(int playerId)
    {
        playerStatusList.RemoveAll(state => state.GetPlayerId() == playerId);
        UpdatePlayerListComponent();
    }

    private void UpdatePlayerListComponent()
    {
        if (playerListComponent) playerListComponent.UpdatePlayerList(playerStatusList);
    }

    public Inventory CreatePlayerInventory()
    {
        Inventory newInventory = InventorySystem.CreateNewInventoryBasedOn(defaultPlayerInventoryTemplate, InventoryItemWasChanged);
        UIBackPackComponent.SetLocalPlayerInventory(newInventory);
        return newInventory;
    }

    private void InventoryItemWasChanged()
    {
        UIBackPackComponent.UpdateBackpack();
    }

    public static PlayerGameState CreatePlayerGameState(int playerId, string name, Color color, int startGold)
    {
        return new PlayerGameState(playerId, name, color, startGold);
    }
}
