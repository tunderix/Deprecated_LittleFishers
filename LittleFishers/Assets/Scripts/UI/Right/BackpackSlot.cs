using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BackpackSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countLabel;

    [SerializeField]
    public InventoryObject item;
}
