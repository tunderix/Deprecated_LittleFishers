using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using LittleFishers.LFInventory;

public class LFNetworkManager : NetworkManager
{
    int clientIndex;

    [Header("Little Fishers")]
    [SerializeField] private InventoryTemplate_Player playerInventoryTemplate;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject go = Instantiate(playerPrefab);
        Player player = go.GetComponent<Player>();
        player.CreateInventoryBasedOn(playerInventoryTemplate);
        player.playerId = clientIndex;
        clientIndex++;

        NetworkServer.AddPlayerForConnection(conn, go);
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        //hut.InitializeHut(this.inventorySystem);
    }
}