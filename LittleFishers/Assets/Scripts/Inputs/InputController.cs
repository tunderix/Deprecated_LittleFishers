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
    void Awake()
    {
        this.mouseControls = this.gameObject.GetComponent<MouseControls>();
        this.fishingController = this.gameObject.GetComponent<FishingController>();
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
        }
    }

    private void LeftMouseClick(GameObject clickedGO)
    {

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
