using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public int playerId;

    [SerializeField] private Inventory playerInventory;
    [SerializeField] private PlayerStats playerStats;

    [Header("Player Default Stats")]
    [SerializeField] private int defaultPlayerStrength;
    [SerializeField] private int defaultPlayerExperience;

    private ExperienceTrack experienceTrack;
    private LevelTrack levelTracker;

    private GameLogic gameLogic;

    void Awake()
    {
        experienceTrack = GameObject.Find("ExperienceTrack").GetComponent<ExperienceTrack>();
        levelTracker = GameObject.Find("LevelIndicator").GetComponent<LevelTrack>();
        playerStats = new PlayerStats(defaultPlayerExperience, defaultPlayerStrength);
        gameLogic = (GameLogic)GameObject.FindGameObjectWithTag("KrakenTheGod").GetComponent<GameLogic>();
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

    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        //Guard if gamelogic was found.
        if (!gameLogic) return;
        Color playerColor = LittleFishersHelpers.PlayerColor(isLocalPlayer);
        string playerName = isLocalPlayer ? "Me" : "Unknown";
        PlayerGameState gameState = GameLogic.CreatePlayerGameState(playerId, playerName, playerColor, 0);
        this.playerInventory = gameLogic.CreatePlayerInventory();
        gameLogic.AddPlayerToStateListing(gameState);
    }

    public override void OnStopClient()
    {
        base.OnStopClient();

        //Guard if gamelogic was found.
        if (!gameLogic) return;

        gameLogic.RemovePlayerFromStateListing(playerId);
    }

    public Inventory GetPlayerInventory()
    {
        return playerInventory;
    }

    public PlayerStats GetPlayerStats()
    {
        return playerStats;
    }
}
