using UnityEngine;

public delegate void OnMouseLeftButtonClick(GameObject go);
public delegate void OnMouseRightButtonClick(GameObject go, Vector3 hitpoint);

public interface IMouseControls
{
    InputController inputController { get; set; }

    Vector3 MouseDownPoint { get; set; }
    Vector3 MouseUpPoint { get; set; }
    Vector3 CurrentMousePoint { get; set; }
}
