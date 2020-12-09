using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class InputController : MonoBehaviour
{

    //Variables
    RaycastHit hit;
    private static Vector3 MouseDownPoint;
    private static Vector3 MouseUpPoint;
    private static Vector3 CurrentMousePoint;
    private static GameObject rayCastedObject;
    GameObject god;

    public GUIStyle mouseDragSkin;
    private bool userIsDragging;
    private static Vector3 mouseDragStart;

    //GUI
    private float boxWidth;
    private float boxHeight;
    private float boxTop;
    private float boxLeft;
    private Vector2 boxStart;
    private Vector2 boxFinish;

    public static ArrayList unitsInDrag = new ArrayList();
    public static ArrayList unitsOnScreen = new ArrayList();
    private bool finishedDragOnThisFrame;
    // Use this for initialization
    void Start()
    {
        god = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        //filter UI CLICKs
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //Shoot Raycasts to read material and colliders
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("RayCasting");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {       //Raycasting

                CurrentMousePoint = hit.point;
                //Store raycast CLICKS
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    MouseDownPoint = hit.point;
                    rayCastedObject = hit.collider.gameObject;
                    mouseDragStart = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                {
                    userIsDragging = true;
                }
                else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
                {
                    userIsDragging = false;
                    MouseUpPoint = hit.point;
                }

                //Check what Object raycast HIT
                if (rayCastedObject != null)
                {
                    if (Input.GetMouseButtonUp(0) && DidUserClickMouse(MouseDownPoint))
                    {
                        LeftClick(hit.collider.gameObject);
                    }
                    if (Input.GetMouseButtonUp(1) && DidUserClickMouse(MouseDownPoint))
                    {
                        RightClick(hit.collider.gameObject, hit.point);
                    }
                }
            }
        }



        if (userIsDragging)
        {
            boxWidth = Camera.main.WorldToScreenPoint(MouseDownPoint).x - Camera.main.WorldToScreenPoint(CurrentMousePoint).x;
            boxHeight = Camera.main.WorldToScreenPoint(MouseDownPoint).y - Camera.main.WorldToScreenPoint(CurrentMousePoint).y;

            boxLeft = Input.mousePosition.x;
            boxTop = (Screen.height - Input.mousePosition.y) - boxHeight;

            if (FloatToBool(boxWidth))
            {
                if (FloatToBool(boxHeight))
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
                if (!FloatToBool(boxWidth))
                {
                    if (FloatToBool(boxHeight))
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

        boxFinish = new Vector2(boxStart.x + Unsigned(boxWidth), (boxStart.y - Unsigned(boxHeight)));

        //Debug.Log("Start: " + boxStart + ", Finish:" + boxFinish);
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {

    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        if (userIsDragging)
        {
            GUI.Box(new Rect(boxLeft, boxTop, boxWidth, boxHeight), "", mouseDragSkin);
        }
    }

    public static float Unsigned(float val)
    {
        if (val < 0f)
        {
            val *= -1;
        }
        return val;
    }

    public static bool FloatToBool(float Float)
    {
        if (Float < 0f)
        {
            return false;
        }
        else return true;
    }

    void LeftClick(GameObject clickedGO)
    {

    }

    void RightClick(GameObject clickedGO, Vector3 hitpoint)
    {
        GameObject.FindGameObjectWithTag("PlayerSelf").GetComponent<Player>().MoveTo(hitpoint);
    }

    public bool DidUserClickMouse(Vector3 hitPoint)
    {
        float clickZone = 1.3f;
        if
            (
                (MouseDownPoint.x < hitPoint.x + clickZone && MouseDownPoint.x > hitPoint.x - clickZone) &&
                (MouseDownPoint.y < hitPoint.y + clickZone && MouseDownPoint.y > hitPoint.y - clickZone) &&
                (MouseDownPoint.z < hitPoint.z + clickZone && MouseDownPoint.z > hitPoint.z - clickZone)
            )
            return true;
        else return false;
    }

    private bool HasSelectionChild(GameObject GO)
    {
        for (int i = 0; i < GO.transform.GetChildCount(); i++)
        {
            Transform transform = GO.transform.GetChild(i);
            if (transform.name == "Selectable")
            {
                return true;
            }
        }
        return false;
    }

    private bool isFisher(GameObject GO)
    {
        if (GO.tag.Contains("Fisher"))
        {
            return true;
        }
        return false;
    }

    private bool canMove(GameObject GO)
    {
        if (GO.GetComponent<ClickToMovement>())
        {
            return true;
        }

        return false;
    }


    public static bool UnitWithinScreenSpace(Vector2 UnitScreenPos)
    {
        if ((UnitScreenPos.x < Screen.width && UnitScreenPos.y < Screen.height) && (UnitScreenPos.x > 0f && UnitScreenPos.y > 0f))
        {
            return true;
        }
        return false;
    }

    public static void RemoveFromOnScreenUnits(GameObject unit)
    {
        for (int i = 0; i < unitsOnScreen.Count; i++)
        {
            GameObject unitObj = unitsOnScreen[i] as GameObject;
            if (unit == unitObj)
            {
                unitsOnScreen.RemoveAt(i);
                return;
            }
            return;
        }
    }
}
