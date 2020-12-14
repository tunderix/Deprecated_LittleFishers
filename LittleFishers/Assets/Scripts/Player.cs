using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public int playerId;

    [SerializeField]
    private Inventory playerInventory;

    public void MoveTo(Vector3 newPosition)
    {
        if (isLocalPlayer)
            this.GetComponentInChildren<ClickToMovement>().MoveTo(newPosition);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        this.tag = "PlayerSelf";
    }
}
