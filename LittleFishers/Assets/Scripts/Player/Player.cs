using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using LittleFishers.Environment;
using LittleFishers.LFInventory;

[RequireComponent(typeof(Collector))]
public class Player : NetworkBehaviour
{
    public int playerId;

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Inventory_Player playerInventory;

    [Header("Player Default Stats")]
    [SerializeField] private int defaultPlayerStrength;
    [SerializeField] private int defaultPlayerExperience;

    private ExperienceTrack experienceTrack;
    private LevelTrack levelTracker;

    private GameLogic gameLogic;
    public Inventory_Player PlayerInventory { get => playerInventory; }

    void Awake()
    {
        experienceTrack = GameObject.Find("ExperienceTrack").GetComponent<ExperienceTrack>();
        levelTracker = GameObject.Find("LevelIndicator").GetComponent<LevelTrack>();
        playerStats = new PlayerStats(defaultPlayerExperience, defaultPlayerStrength);
        gameLogic = (GameLogic)GameObject.FindGameObjectWithTag("KrakenTheGod").GetComponent<GameLogic>();

        SubscribeToCollectionOfItems();
    }

    public void MoveTo(Vector3 newPosition)
    {
        if (isLocalPlayer)
            this.GetComponentInChildren<ClickToMovement>().MoveTo(newPosition);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        this.tag = "PlayerSelf";
        playerStats.Experience.SubscribeToExperienceChange(experienceTrack.playerExperienceAmountChanged);
        playerStats.Experience.SubscribeToLevelChange(levelTracker.OnLevelChanged);
        GameObject.Find("LittleFishersUI").GetComponent<LittleFishersUI>().ReferenceLocalPlayer(this);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        //Guard if gamelogic was found.
        if (!gameLogic) return;
        Color playerColor = LittleFishersHelpers.PlayerColor(isLocalPlayer);
        string playerName = isLocalPlayer ? "Me" : "Unknown";
        PlayerGameState gameState = GameLogic.CreatePlayerGameState(playerId, playerName, playerColor, 0);
        //this.playerInventory = gameLogic.CreatePlayerInventory();
        gameLogic.AddPlayerToStateListing(gameState);
    }

    public override void OnStopClient()
    {
        base.OnStopClient();

        //Guard if gamelogic was found.
        if (!gameLogic) return;

        gameLogic.RemovePlayerFromStateListing(playerId);
    }

    public PlayerStats GetPlayerStats()
    {
        return playerStats;
    }

    public void CreateInventoryBasedOn(InventoryTemplate_Player playerInventoryTemplate)
    {
        playerInventory = new Inventory_Player(playerInventoryTemplate);
    }

    private void SubscribeToCollectionOfItems()
    {
        this.GetComponent<Collector>().OnCollected = OnInventoryItemCollected;
    }

    public void OnInventoryItemCollected(InventoryItem inventoryItem)
    {
        playerInventory.AddItem(inventoryItem);
    }
}
