using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LFNetworkManager : NetworkManager
{
    int clientIndex;

    [SerializeField]
    private Hut hut;
    [SerializeField]
    private InventorySystem inventorySystem;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject go = Instantiate(playerPrefab);
        Player player = go.GetComponent<Player>();
        player.playerId = clientIndex;
        clientIndex++;

        NetworkServer.AddPlayerForConnection(conn, go);
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        hut.InitializeHut(this.inventorySystem);
    }
}