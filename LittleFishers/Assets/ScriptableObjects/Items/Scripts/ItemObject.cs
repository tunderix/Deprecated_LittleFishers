using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType itemType;
    [TextArea(15, 20)]
    public string description;
}
