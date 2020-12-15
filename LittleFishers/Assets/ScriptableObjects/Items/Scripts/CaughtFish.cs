using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish", menuName = "Inventory System/Items/Fish")]
public class CaughtFish : ItemObject
{
    void Awake()
    {
        itemType = ItemType.Fish;
    }
}
