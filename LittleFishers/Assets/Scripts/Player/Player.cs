using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public int playerId;

    [SerializeField]
    private Inventory playerInventory;
    [SerializeField]
    private PlayerStats playerStats;

    [Header("Player Default Stats")]
    [SerializeField]
    private int defaultPlayerStrength;
    [SerializeField]
    private int defaultPlayerExperience;


    void Awake()
    {
        playerStats = new PlayerStats(defaultPlayerExperience, defaultPlayerStrength);
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
