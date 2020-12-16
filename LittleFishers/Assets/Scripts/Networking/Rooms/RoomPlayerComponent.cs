using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomPlayerComponent : MonoBehaviour
{
    [SerializeField]
    private Image playerReadyImage;
    [SerializeField]
    private TextMeshProUGUI playerNameText;

    public void SetPlayerReady(bool isReady)
    {
        playerReadyImage.sprite = Resources.Load<Sprite>("Resources/Sprites/button_attention_" + (isReady ? "green" : "yellow"));
    }

    public void SetPlayerName(string playerName)
    {
        playerNameText.SetText(playerName);
    }
}
