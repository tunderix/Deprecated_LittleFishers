using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LFNetworkManager : NetworkManager
{
    int clientIndex;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject go = Instantiate(playerPrefab);
        Player player = go.GetComponent<Player>();
        player.playerId = clientIndex;
        go.tag = "PlayerSelf";
        clientIndex++;

        NetworkServer.AddPlayerForConnection(conn, go);
    }
}