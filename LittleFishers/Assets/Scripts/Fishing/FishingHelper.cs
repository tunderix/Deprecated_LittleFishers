
using UnityEngine;
using UnityEditor;

public class FishingHelper
{
    public static bool canStartFishing(float throwRange, Vector3 playerPosition, Vector3 targetFishingPosition, GameObject clickedGO)
    {
        float throwDistance = Vector3.Distance(playerPosition, targetFishingPosition);
        return (clickedGO.tag == "Water" && throwDistance < throwRange);
    }

    public static CaughtFish fishObjectBySize(FishSize size)
    {
        switch (size)
        {
            default:
                return (CaughtFish)ScriptableObject.CreateInstance(typeof(CaughtFish));
        }
    }
}
