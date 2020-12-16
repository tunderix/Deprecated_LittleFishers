using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerGameState
{
    private int playerId;
    private string playerName;
    private Color playerColor;
    private int goldAmount;

    public PlayerGameState()
    {
        this.playerName = "Player";
        this.playerColor = Color.blue;
        this.goldAmount = 0;
    }

    public PlayerGameState(int _playerId, string _playerName, Color _playerColor, int _goldAmount)
    {
        this.playerName = _playerName;
        this.playerColor = _playerColor;
        this.goldAmount = _goldAmount;
        this.playerId = _playerId;
    }

    public string GetPlayerName()
    {
        return this.playerName;
    }

    public Color GetPlayerColor()
    {
        return this.playerColor;
    }

    public int GetPlayerGoldAmount()
    {
        return this.goldAmount;
    }

    public int GetPlayerId()
    {
        return this.playerId;
    }
}
