using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControls : MonoBehaviour
{
    private InputController inputController;

    // Overall Mouse Properties
    private RaycastHit hit;
    private static Vector3 MouseDownPoint;
    private static Vector3 MouseUpPoint;
    private static Vector3 CurrentMousePoint;
    private static GameObject rayCastedObject;

    // Dragging
    private bool userIsDragging;
    private static Vector3 mouseDragStart;

    //GUI Properties for highlighting
    private float boxWidth;
    private float boxHeight;
    private float boxTop;
    private float boxLeft;
    private Vector2 boxStart;
    private Vector2 boxFinish;
    public GUIStyle skin;

    public delegate void OnMouseLeftButtonClick(GameObject go);
    public delegate void OnMouseRightButtonClick(GameObject go, Vector3 hitpoint);
    public OnMouseLeftButtonClick onMouseLeftButtonClick;
    public OnMouseRightButtonClick onMouseRightButtonClick;


    void Awake()
    {
        this.inputController = this.gameObject.GetComponent<InputController>();
    }

    void Update()
    {
        DetectClicksAndUpdateMousePoints();
        DetectDragging();
    }

    private void DetectClicksAndUpdateMousePoints()
    {
        //filter UI CLICKs
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //Shoot Raycasts to read material and colliders
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                CurrentMousePoint = hit.point;
                //Store raycast CLICKS
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    MouseDownPoint = hit.point;
                    rayCastedObject = hit.collider.gameObject;
                    mouseDragStart = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                    userIsDragging = true;
                else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
                {
                    userIsDragging = false;
                    MouseUpPoint = hit.point;
                }

                //Check what Object raycast HIT
                if (rayCastedObject != null && InputHelpers.DidUserClickMouse(MouseDownPoint, MouseUpPoint))
                {
                    if (Input.GetMouseButtonUp(0)) LeftClick(hit.collider.gameObject);
                    if (Input.GetMouseButtonUp(1)) RightClick(hit.collider.gameObject, hit.point);
                }
            }
        }
    }

    private void DetectDragging()
    {
        if (userIsDragging)
        {
            boxWidth = Camera.main.WorldToScreenPoint(MouseDownPoint).x - Camera.main.WorldToScreenPoint(CurrentMousePoint).x;
            boxHeight = Camera.main.WorldToScreenPoint(MouseDownPoint).y - Camera.main.WorldToScreenPoint(CurrentMousePoint).y;

            boxLeft = Input.mousePosition.x;
            boxTop = (Screen.height - Input.mousePosition.y) - boxHeight;

            if (InputHelpers.FloatToBool(boxWidth))
            {
                if (InputHelpers.FloatToBool(boxHeight))
                {
                    boxStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y + boxHeight);
                }
                else
                {
                    boxStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                }
            }
            else
            {
                if (!InputHelpers.FloatToBool(boxWidth))
                {
                    if (InputHelpers.FloatToBool(boxHeight))
                    {
                        boxStart = new Vector2(Input.mousePosition.x + boxWidth, Input.mousePosition.y + boxHeight);
                    }
                    else
                    {
                        boxStart = new Vector2(Input.mousePosition.x + boxWidth, Input.mousePosition.y);
                    }
                }
            }
        }

        boxFinish = new Vector2(boxStart.x + InputHelpers.Unsigned(boxWidth), (boxStart.y - InputHelpers.Unsigned(boxHeight)));
    }

    private void LeftClick(GameObject clickedGO)
    {
        onMouseLeftButtonClick(clickedGO); //InputController delegate
    }

    private void RightClick(GameObject clickedGO, Vector3 hitpoint)
    {
        onMouseRightButtonClick(clickedGO, hitpoint); //InputController delegate
    }
}
