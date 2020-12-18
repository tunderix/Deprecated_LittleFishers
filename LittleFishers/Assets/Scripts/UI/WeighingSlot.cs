using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeighingSlot : MonoBehaviour
{
    public int slotIndex;

    [SerializeField]
    public InventoryObject item;

    [SerializeField]
    private Image image;

    public void SetImage()
    {
        if (item != null)
        {
            image.sprite = item.inventoryIcon;
        }
    }
}
