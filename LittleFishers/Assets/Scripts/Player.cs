using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public int playerId = -1;

    public void MoveTo(Vector3 newPosition)
    {
        this.GetComponentInChildren<ClickToMovement>().MoveTo(newPosition);
    }
}
