using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerListComponent : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameLabel;
    [SerializeField]
    private TextMeshProUGUI goldLabel;

    public void SetPlayerName(string _playerName)
    {
        nameLabel.SetText(_playerName);
    }

    public void SetPlayerGoldAmount(int _goldAmount)
    {
        goldLabel.SetText(_goldAmount.ToString());
    }

    public void SetBackgroundColor(Color _color)
    {
        this.GetComponent<Image>().color = _color;
    }
}
