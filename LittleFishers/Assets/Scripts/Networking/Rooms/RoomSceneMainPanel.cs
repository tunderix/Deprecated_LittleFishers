using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RoomSceneMainPanel : MonoBehaviour
{
    public GameObject newRoomView;
    public GameObject joinRoomView;
    public GameObject joinByIpView;
    public GameObject roomView;

    public void CloseAllViews()
    {
        newRoomView.SetActive(false);
        joinRoomView.SetActive(false);
        joinByIpView.SetActive(false);
    }

    public void OpenRoomView()
    {
        roomView.SetActive(true);
    }
}
