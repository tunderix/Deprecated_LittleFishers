
[System.Serializable]
public class FishingRod : InventoryObject
{
    private int _strengthModifier;
    private int _range;
    private int _attractionModifier;

    public FishingRod(RodTemplate rodTemplate)
    {
        this.itemName = rodTemplate.itemName;
        this._strengthModifier = rodTemplate.strengthModifier;
        this._range = rodTemplate.range;
        this._attractionModifier = rodTemplate.attractionModifier;
        this.description = rodTemplate.description;
        this.inventoryIcon = rodTemplate.backpackIcon;
        this.goldValue = decideGoldValue(rodTemplate.minGoldValue, rodTemplate.maxGoldValue);
        this.MaxStackSize = 1;
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
