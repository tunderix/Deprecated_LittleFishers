
[System.Serializable]
public class FishingBait : InventoryObject
{
    private int _strengthModifier;
    private int _attractionModifier;

    public FishingBait(BaitTemplate baitTemplate)
    {
        this.itemName = baitTemplate.itemName;
        this._strengthModifier = baitTemplate.strengthModifier;
        this._attractionModifier = baitTemplate.attractionModifier;
        this.description = baitTemplate.description;
        this.inventoryIcon = baitTemplate.backpackIcon;
        this.goldValue = decideGoldValue(baitTemplate.minGoldValue, baitTemplate.maxGoldValue);
    }

    private int decideGoldValue(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public int StrengthModifier
    {
        get
        {
            return this._strengthModifier;
        }
    }
}
