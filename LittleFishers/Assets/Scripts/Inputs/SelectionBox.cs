using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectionBox
{
    public Vector3 baseMin, baseMax;

    public Vector3 Center
    {
        get
        {
            Vector3 center = baseMin + (baseMax - baseMin) * 0.5f;
            center.y = (baseMax - baseMin).magnitude * 0.5f;
            return center;
        }
    }

    public Vector3 Size
    {
        get
        {
            return new Vector3(Mathf.Abs(baseMax.x - baseMin.x), (baseMax - baseMin).magnitude, Mathf.Abs(baseMax.z - baseMin.z));
        }
    }

    public Vector3 Extents
    {
        get
        {
            return Size * 0.5f;
        }
    }
}
