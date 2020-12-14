using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Worm Object", menuName = "Inventory System/Items/Worm")]
public class Worm : ItemObject
{
    void Awake()
    {
        itemType = ItemType.Bait;
    }
}
