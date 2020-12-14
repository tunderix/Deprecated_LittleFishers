using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite backpackIcon;
    public ItemType itemType;
    [TextArea(15, 20)]
    public string description;
}
