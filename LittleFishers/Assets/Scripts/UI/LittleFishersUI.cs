using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using LittleFishers.UI;

public class LittleFishersUI : MonoBehaviour
{
    [SerializeField] private PlayerStatisticsPanel playerList;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private KeybindLayout keybindLayout;
    [SerializeField] private GameObject shopLayout;
    [SerializeField] private ExperienceTrack experienceTrack;
    [SerializeField] private UI_Backpack backpack;

    [SerializeField] private bool playerListHidden;
    [SerializeField] private bool backpackHidden;
    [SerializeField] private bool mainMenuHidden;

    private Player _localPlayer;

    void Start()
    {
        HideInitialUIComponents();
    }

    private void HideInitialUIComponents()
    {
        playerList.gameObject.SetActive(!playerListHidden);
        mainMenu.gameObject.SetActive(!mainMenuHidden);
        HideKeybindLayout();
    }

    public void TogglePlayerList()
    {
        playerListHidden = !playerListHidden;
        playerList.gameObject.SetActive(!playerListHidden);
        //if (!playerListHidden) UpdatePlayerListComponent();
    }

    public void ToggleBackpack()
    {
        backpackHidden = !backpackHidden;
        backpack.gameObject.SetActive(!backpackHidden);
        if (!backpackHidden) backpack.ShowInventory(_localPlayer.PlayerInventory);
    }

    public void ToggleMainMenu()
    {
        mainMenuHidden = !mainMenuHidden;
        mainMenu.gameObject.SetActive(!mainMenuHidden);
    }

    public void HideKeybindLayout()
    {
        keybindLayout.gameObject.SetActive(false);
    }

    public void HideShopLayout()
    {
        shopLayout.gameObject.SetActive(false);
    }

    public void ReferenceLocalPlayer(Player player)
    {
        _localPlayer = player;
    }

    public void UpdateUI()
    {

    }
}
