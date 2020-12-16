using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomComponent : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI roomNameLabel;
    [SerializeField]
    private TextMeshProUGUI roomCountLabel;

    public void SetName(string text)
    {
        roomNameLabel.SetText(text);
    }

    public void SetRoomCount(string text)
    {
        roomCountLabel.SetText(text);
    }
}
