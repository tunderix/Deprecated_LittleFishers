using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private MouseControls mouseControls;
    private FishingController fishingController;
    [SerializeField]
    private LittleFishersUI littleFishersUI;
    private List<Selectable> selectedObjects;

    void Awake()
    {
        this.mouseControls = this.gameObject.GetComponent<MouseControls>();
        this.fishingController = this.gameObject.GetComponent<FishingController>();
        selectedObjects = new List<Selectable>();
    }
    void Start()
    {
        this.mouseControls.onMouseLeftButtonClick = LeftMouseClick;
        this.mouseControls.onMouseRightButtonClick = RightMouseClick;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            littleFishersUI.TogglePlayerList();
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            littleFishersUI.ToggleBackpack();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            littleFishersUI.ToggleMainMenu();
            littleFishersUI.HideKeybindLayout();
            littleFishersUI.HideShopLayout();
        }
    }

    [SerializeField]
    private Selectable sel;

    private void LeftMouseClick(GameObject clickedGO)
    {
        if (sel != null) sel.IsSelected = false;
        sel = null;

        // Add selectable object to be selected 
        Selectable selectable = clickedGO.GetComponent<Selectable>();
        if (selectable != null)
        {
            sel = selectable;
            sel.IsSelected = true;
        }
    }

    private void RightMouseClick(GameObject clickedGO, Vector3 hitpoint)
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerSelf");
        FishPool fishPool = clickedGO.GetComponent<FishPool>();
        if (FishingHelper.canStartFishing(fishingController.throwDistance, player.transform.position, hitpoint, clickedGO) && fishPool)
        {
            // TODO - Fix This
            fishingController.StartFishing(hitpoint, fishPool, player.GetComponent<Player>());
        }
        else
        {
            player.GetComponent<Player>().MoveTo(hitpoint);
        }
    }
}
