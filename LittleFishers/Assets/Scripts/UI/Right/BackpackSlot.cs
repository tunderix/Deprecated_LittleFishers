using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BackpackSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countLabel;

    public int backpackSlotId;

    [SerializeField]
    public InventoryObject item;
}
