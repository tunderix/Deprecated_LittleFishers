using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingTarget : MonoBehaviour
{

    [SerializeField] private Animator _ftAnimator;

    public void TriggerFishOn()
    {
        this._ftAnimator.SetTrigger("FishOn");
    }

    public void TriggerSuccess()
    {
        this._ftAnimator.SetTrigger("FishingSuccess");
    }

    public void TriggerDespawn()
    {
        this._ftAnimator.SetTrigger("Despawn");
    }
}
