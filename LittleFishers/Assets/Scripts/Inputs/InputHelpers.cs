using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHelpers
{
    public static float Unsigned(float val)
    {
        if (val < 0f)
        {
            val *= -1;
        }
        return val;
    }

    public static bool FloatToBool(float Float)
    {
        if (Float < 0f)
        {
            return false;
        }
        else return true;
    }

    public static bool DidUserClickMouse(Vector3 MouseDownPoint, Vector3 hitPoint)
    {
        float clickZone = 1.3f;
        if
            (
                (MouseDownPoint.x < hitPoint.x + clickZone && MouseDownPoint.x > hitPoint.x - clickZone) &&
                (MouseDownPoint.y < hitPoint.y + clickZone && MouseDownPoint.y > hitPoint.y - clickZone) &&
                (MouseDownPoint.z < hitPoint.z + clickZone && MouseDownPoint.z > hitPoint.z - clickZone)
            )
            return true;
        else return false;
    }

    public static bool UnitWithinScreenSpace(Vector2 UnitScreenPos)
    {
        if ((UnitScreenPos.x < Screen.width && UnitScreenPos.y < Screen.height) && (UnitScreenPos.x > 0f && UnitScreenPos.y > 0f))
        {
            return true;
        }
        return false;
    }
}
