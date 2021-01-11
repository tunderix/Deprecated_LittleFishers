using UnityEngine;

[System.Serializable]
public class BaitSlot
{
    [SerializeField] private FishingBait _equippedFishingBait;
    public OnVariableChangeDelegate OnInventoryItemChanged;
    private UIBaitSlot UISlot;

    public FishingBait CurrentFishingBait
    {
        get { return this._equippedFishingBait; }
    }

    public bool IsBaitEquipped
    {
        get { return this._equippedFishingBait != null; }
    }

    public void RegisterUISlot(UIBaitSlot slot)
    {
        this.UISlot = slot;
    }

    public FishingBait EquipBait(FishingBait bait)
    {
        FishingBait currentFishingBait = _equippedFishingBait;
        _equippedFishingBait = bait;
        if (this.UISlot != null) this.UISlot.Bait = CurrentFishingBait;
        OnInventoryItemChanged();
        return currentFishingBait;
    }

    public void RegisterOnBaitChanged(OnVariableChangeDelegate onInventoryItemChanged)
    {
        OnInventoryItemChanged += onInventoryItemChanged;
    }
}
