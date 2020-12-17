using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ItemObject : ScriptableObject
{
    public GameObject onWorldPrefab;
    public Sprite backpackIcon;
    public ItemType itemType;
    public string itemName;
    [TextArea(15, 20)]
    public string description;
    public int minGoldValue;
    public int maxGoldValue;
}
