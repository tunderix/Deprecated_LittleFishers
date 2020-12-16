using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFishersHelpers
{
    public static void DestroyAllChilds(Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public static Color PlayerColor(bool isLocalPlayer)
    {
        return isLocalPlayer ? Color.green : Color.red;
    }
}
