using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RoomList : MonoBehaviour
{
    private List<string> roomNames;

    [SerializeField]
    private GameObject listComponent;

    private void Awake()
    {
        this.roomNames = new List<string>();
    }

    void Start()
    {
        UpdateView();
    }

    public void AddRoomWithName(string name)
    {
        roomNames.Add(name);
        UpdateView();
    }

    private void UpdateView()
    {
        LittleFishersHelpers.DestroyAllChilds(this.transform);

        foreach (string roomName in this.roomNames)
        {
            CreateRoomListComponent(roomName);
        }
    }

    private void CreateRoomListComponent(string roomName)
    {
        GameObject newListComponent = GameObject.Instantiate(listComponent);
        newListComponent.transform.SetParent(this.transform);
        newListComponent.GetComponent<RoomComponent>().SetName(roomName);
    }
}
