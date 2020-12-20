using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBaitSlot : MonoBehaviour
{
    [SerializeField] private Image baitIcon;
    public FishingBait Bait;

    public void UpdateContents()
    {
        if (Bait == null) return;
        baitIcon.sprite = Bait.inventoryIcon;
    }

    public void UpdateContents(FishingBait bait)
    {
        baitIcon.sprite = bait.inventoryIcon;
    }
}
