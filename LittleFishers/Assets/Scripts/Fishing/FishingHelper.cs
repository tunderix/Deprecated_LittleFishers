using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHelper
{
    public static bool canStartFishing(Vector3 playerPosition, Vector3 targetFishingPosition, GameObject clickedGO)
    {
        bool canStartFishing = false;
        float throwTreshold = GameObject.FindGameObjectWithTag("FishingController").GetComponent<FishingController>().throwDistance;
        float throwDistance = Vector3.Distance(playerPosition, targetFishingPosition);
        if (clickedGO.tag == "Water" && throwDistance < throwTreshold)
        {
            canStartFishing = true;
        }
        return canStartFishing;
    }
}
