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

    public static Rect RectTransformToScreenSpace(RectTransform transform)
    {
        Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
        return new Rect((Vector2)transform.position - (size * 0.5f), size);
    }
}
