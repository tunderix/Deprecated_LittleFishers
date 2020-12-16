using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomPanel : MonoBehaviour
{
    [SerializeField]
    private VerticalLayoutGroup roomPlayerList;
    [SerializeField]
    private GameObject roomPlayerPrefab;
    [SerializeField]
    private GameObject roomLocalPlayerPrefab;

    public void UpdatePlayerList(List<LFRoomPlayer> roomPlayers)
    {
        LittleFishersHelpers.DestroyAllChilds(roomPlayerList.transform);
        foreach (LFRoomPlayer roomPlayer in roomPlayers)
        {

            GameObject newRoomPlayerComponent = GameObject.Instantiate(roomPlayerPrefab);
            newRoomPlayerComponent.transform.parent = roomPlayerList.transform;
            RoomPlayerComponent rpc = newRoomPlayerComponent.GetComponent<RoomPlayerComponent>();
            if (rpc)
            {
                rpc.SetPlayerName(roomPlayer.playerName);
                rpc.SetPlayerReady(roomPlayer.isReady);
            }
        }
    }
}
