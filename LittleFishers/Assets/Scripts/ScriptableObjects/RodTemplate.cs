using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rod Object", menuName = "Inventory System/Items/Rod")]
public class RodTemplate : ItemObject
{
    [Header("Fishing Attributes")]
    public int strengthModifier;
    public int range;
    public int attractionModifier;
}

