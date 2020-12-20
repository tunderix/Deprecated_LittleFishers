using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFishingRodSlot : MonoBehaviour
{
    [SerializeField] private Image rodIcon;
    public FishingRod Rod;

    public void UpdateContents()
    {
        if (Rod == null) return;
        rodIcon.sprite = Rod.inventoryIcon;
    }

    public void UpdateContents(FishingRod fishingRod)
    {
        rodIcon.sprite = fishingRod.inventoryIcon;
    }
}
