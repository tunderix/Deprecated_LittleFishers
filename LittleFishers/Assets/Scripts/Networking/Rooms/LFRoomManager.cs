using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class LFRoomManager : NetworkRoomManager
{
    [Header("LittleFishers Configurations")]
    [SerializeField]
    private TextMeshProUGUI ipAddressEditText;
    [SerializeField]
    private RoomSceneMainPanel mainPanel;
    [SerializeField]
    private RoomPanel roomPanel;

    //Called from join by ip form through even system. 
    public void JoinByIP()
    {
        string ipAddress = ipAddressEditText.text;
        this.StartClient();
    }

    public override void OnRoomStartClient()
    {
        base.OnRoomStartClient();
        UpdateRoomPlayerPanel();
    }

    public override void OnRoomStartHost()
    {
        base.OnRoomStartHost();

    }

    public override void OnRoomClientConnect(NetworkConnection conn)
    {
        base.OnRoomClientConnect(conn);
    }

    private void UpdateRoomPlayerPanel()
    {
        List<LFRoomPlayer> lfRoomPlayers = new List<LFRoomPlayer>();
        foreach (PendingPlayer player in pendingPlayers)
        {
            //TODO deal with local player findings...
            lfRoomPlayers.Add(new LFRoomPlayer(player.roomPlayer.name, false, player.conn.isReady));
        }

        mainPanel.OpenRoomView();
        roomPanel.UpdatePlayerList(lfRoomPlayers);
    }
}

public struct LFRoomPlayer
{
    public string playerName;
    public bool isLocal;
    public bool isReady;

    public LFRoomPlayer(string _playerName, bool _isLocal, bool _isReady)
    {
        this.playerName = _playerName;
        this.isLocal = _isLocal;
        this.isReady = _isReady;
    }
}