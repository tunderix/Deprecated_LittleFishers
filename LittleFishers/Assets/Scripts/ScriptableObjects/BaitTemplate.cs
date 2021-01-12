using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bait Object", menuName = "Inventory System/Items/Bait")]
public class BaitTemplate : ItemObject
{
    [Header("Fishing Attributes")]
    public int strengthModifier;
    public int attractionModifier;
}

