using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControls : MonoBehaviour, IMouseControls
{
    public InputController inputController { get; set; }

    // Overall Mouse Properties
    private RaycastHit hit;
    private Ray ray;

    /// <value>Position where mouse left click was pressed initially</value>
    public Vector3 MouseDownPoint { get; set; }
    /// <value>Position where mouse left click was released</value>
    public Vector3 MouseUpPoint { get; set; }
    /// <value>Position of raycast from mouse to world</value>
    public Vector3 CurrentMousePoint { get; set; }

    /// <value>A box used for check overlapping colliders</value>
    [SerializeField] private SelectionBox box;

    // Dragging
    public bool _userIsDragging;
    private static Vector3 mouseDragStart;

    void Update()
    {
        DetectClicksAndUpdateMousePoints();
    }

    private void DetectClicksAndUpdateMousePoints()
    {
        // Might need to filter UI CLICKs in future
        // if (!EventSystem.current.IsPointerOverGameObject())
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 100f);


            if (Input.GetMouseButtonDown(0))
            {
                MouseDownPoint = hit.point;
                _userIsDragging = true;
                mouseDragStart = MouseDownPoint;
                box.baseMin = mouseDragStart;
                leftClick(hit.collider.gameObject);
            }
            if (Input.GetMouseButtonDown(1))
            {
                rightClick(hit);
            }
            CurrentMousePoint = hit.point;
            box.baseMax = CurrentMousePoint;
            dragging();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _userIsDragging = false;
        }
    }

    private void dragging()
    {
        InputController.MouseDrag(box);
    }

    private void leftClick(GameObject clickedGO)
    {
        InputController.MouseLeftButtonClick(clickedGO);
    }

    private void rightClick(RaycastHit hit)
    {
        InputController.MouseRightButtonClick(hit.collider.gameObject, hit.point);
    }
}
