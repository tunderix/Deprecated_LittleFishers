using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LittleFishersUI : MonoBehaviour
{
    [SerializeField]
    private Backpack backpack;
    [SerializeField]
    private PlayerStatisticsPanel playerList;
    [SerializeField]
    private MainMenu mainMenu;
    [SerializeField]
    private KeybindLayout keybindLayout;

    [SerializeField]
    private bool playerListHidden;
    [SerializeField]
    private bool backpackHidden;
    [SerializeField]
    private bool mainMenuHidden;

    void Start()
    {
        HideInitialUIComponents();
    }

    private void HideInitialUIComponents()
    {
        playerList.gameObject.SetActive(!playerListHidden);
        backpack.gameObject.SetActive(!backpackHidden);
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
        backpack.ClearBackpack();
        if (!backpackHidden) backpack.UpdateBackpack();
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

    public void UpdateUI()
    {
        backpack.UpdateBackpack();
    }
}
