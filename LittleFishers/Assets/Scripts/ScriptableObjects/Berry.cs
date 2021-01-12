using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Berry Object", menuName = "Inventory System/Items/Berry")]
public class Berry : ItemObject
{
    void Awake()
    {
        itemType = ItemType.Food;
    }
}
