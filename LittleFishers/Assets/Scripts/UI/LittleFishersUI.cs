using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LittleFishersUI : NetworkBehaviour
{
    [SerializeField]
    private Backpack backpack;
    [SerializeField]
    private PlayerStatisticsPanel playerList;
    [SerializeField]
    private MainMenu mainMenu;

    private List<PlayerGameState> playerStatusList;

    private PlayerList playerListComponent;

    [SerializeField]
    private bool playerListHidden;
    [SerializeField]
    private bool backpackHidden;
    [SerializeField]
    private bool mainMenuHidden;

    void Awake()
    {
        this.playerStatusList = new List<PlayerGameState>();
        this.playerListComponent = GameObject.FindGameObjectWithTag("PlayerListPanel").GetComponent<PlayerList>();
    }

    public void TogglePlayerList()
    {
        playerListHidden = !playerListHidden;
        playerList.gameObject.SetActive(playerListHidden);
        if (!playerListHidden) UpdatePlayerListComponent();
    }

    public void ToggleBackpack()
    {
        backpackHidden = !backpackHidden;
        backpack.gameObject.SetActive(backpackHidden);
    }

    public void ToggleMainMenu()
    {
        mainMenuHidden = !mainMenuHidden;
        mainMenu.gameObject.SetActive(mainMenuHidden);
    }

    public void UpdateUI()
    {
        backpack.UpdateBackpack();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        playerStatusList.Add(new PlayerGameState("Player", Color.red, 0));

        UpdatePlayerListComponent();
    }

    private void UpdatePlayerListComponent()
    {
        if (playerListComponent) playerListComponent.UpdatePlayerList(playerStatusList);
    }
}
