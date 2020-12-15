using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerList : MonoBehaviour
{
    [SerializeField]
    private GameObject playerListComponent;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void UpdatePlayerList(List<PlayerGameState> playerStatusList)
    {
        LittleFishersHelpers.DestroyAllChilds(this.transform);

        foreach (PlayerGameState playerState in playerStatusList)
        {
            GameObject listComponent = GameObject.Instantiate(playerListComponent);
            listComponent.transform.SetParent(this.transform);
            PlayerListComponent playerComponent = listComponent.GetComponent<PlayerListComponent>();
            playerComponent.SetPlayerName(playerState.GetPlayerName());
            playerComponent.SetPlayerGoldAmount(playerState.GetPlayerGoldAmount());
            playerComponent.SetBackgroundColor(playerState.GetPlayerColor());
        }
    }
}
