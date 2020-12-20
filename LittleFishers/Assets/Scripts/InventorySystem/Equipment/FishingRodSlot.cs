
public class FishingRodSlot
{
    private FishingRod _equippedFishingRod;
    public OnVariableChangeDelegate OnInventoryItemChanged;
    private UIFishingRodSlot UISlot;

    public FishingRod CurrentFishingRod
    {
        get { return this._equippedFishingRod; }
    }

    public bool IsRodEquipped
    {
        get { return this._equippedFishingRod != null; }
    }

    public void RegisterUISlot(UIFishingRodSlot slot)
    {
        this.UISlot = slot;
    }

    public FishingRod EquipRod(FishingRod rod)
    {
        FishingRod currentFishingRod = _equippedFishingRod;
        _equippedFishingRod = rod;
        if (this.UISlot != null) this.UISlot.Rod = CurrentFishingRod;
        OnInventoryItemChanged();
        return currentFishingRod;
    }

    public void RegisterOnRodChanged(OnVariableChangeDelegate onInventoryItemChanged)
    {
        OnInventoryItemChanged += onInventoryItemChanged;
    }
}
