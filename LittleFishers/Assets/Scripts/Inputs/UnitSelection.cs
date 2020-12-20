using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UnitSelection : MonoBehaviour
{
    [SerializeField] Collider[] unitSelections;

    [SerializeField]
    private bool userIsDragging;

    [SerializeField]
    private RectTransform UnitSelectionBox;

    private Vector2 MouseDownPoint;

    [SerializeField]
    private SelectionBox box;

    private Ray ray;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;

    [SerializeField] Projector selectionProjector;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 100f);
            selectionProjector.enabled = true;

            if (Input.GetMouseButtonDown(0))
            {
                MouseDownPoint = _currentMousePosition;
                userIsDragging = true;
                dragStartPosition = hit.point;
                box.baseMin = dragStartPosition;
            }
            dragCurrentPosition = hit.point;
            box.baseMax = dragCurrentPosition;

            selectionProjector.aspectRatio = box.Size.x / box.Size.z;
            selectionProjector.orthographicSize = box.Size.z * 0.5f;
            selectionProjector.transform.position = box.Center;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectionProjector.enabled = false;
            userIsDragging = false;
            unitSelections = Physics.OverlapBox(box.Center, box.Extents, Quaternion.identity);
        }
    }

    void OnGUI()
    {
        if (!userIsDragging)
        {
            UnitSelectionBox.gameObject.SetActive(false);
            return;
        }

        UnitSelectionBox.gameObject.SetActive(true);
        Vector2 draggingDifference = _currentMousePosition - MouseDownPoint;
        UnitSelectionBox.localPosition = MouseDownPoint;
        UnitSelectionBox.sizeDelta = absoluteDraggingDifference();
        updatePivotsBasedOn(draggingDifference);
    }

    private void updatePivotsBasedOn(Vector2 draggingDifference)
    {
        UnitSelectionBox.pivot = new Vector2(pivotFor(draggingDifference.x), pivotFor(draggingDifference.y));
    }

    private float pivotFor(float value)
    {
        return value >= 0 ? 0 : 1;
    }

    private Vector2 absoluteDraggingDifference()
    {
        return new Vector2(Mathf.Abs(_currentMousePosition.x - MouseDownPoint.x), Mathf.Abs(_currentMousePosition.y - MouseDownPoint.y));
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box.Center, box.Size);
    }
    */

    private Vector2 _currentMousePosition
    {
        get
        {
            return new Vector2(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2));
        }
    }
}
