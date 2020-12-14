using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rod Object", menuName = "Inventory System/Items/Rod")]
public class Rod : ItemObject
{
    void Awake()
    {
        itemType = ItemType.Equipment;
    }
}
