using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void MoveTo(Vector3 newPosition)
    {
        this.GetComponentInChildren<ClickToMovement>().MoveTo(newPosition);
    }
}
