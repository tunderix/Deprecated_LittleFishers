using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState
{
    private string playerName;
    private Color playerColor;
    private int goldAmount;

    public PlayerGameState(string _playerName, Color _playerColor, int _goldAmount)
    {
        this.playerName = _playerName;
        this.playerColor = _playerColor;
        this.goldAmount = _goldAmount;
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
}
