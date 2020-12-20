using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSelection : MonoBehaviour
{
    private List<Selectable> selectedUnits;

    [SerializeField]
    private bool userIsDragging;

    [SerializeField]
    private RectTransform UnitSelectionBox;

    private Vector2 MouseDownPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDownPoint = _currentMousePosition;
            userIsDragging = true;
        }
        else if (Input.GetMouseButtonUp(0)) userIsDragging = false;
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

    private Vector2 _currentMousePosition
    {
        get
        {
            return new Vector2(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2));
        }
    }
}
