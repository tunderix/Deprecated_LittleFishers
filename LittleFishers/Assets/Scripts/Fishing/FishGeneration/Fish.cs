using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish
{
    private FishSize _fishSize;
    private string _fishName;
    private string _fishSizeName;
    private string _description;
    private Sprite _icon;
    private int _minGoldValue;
    private int _maxGoldValue;

    public Fish(FishSize fishSize, CaughtFish caughtFish)
    {
        this._fishSize = fishSize;
        this._fishName = FishingHelper.RandomFishName;
        this._fishSizeName = caughtFish.name;
        this._description = caughtFish.description;
        this._icon = caughtFish.backpackIcon;
        this._maxGoldValue = caughtFish.maxGoldValue;
        this._minGoldValue = caughtFish.minGoldValue;
    }


    public string GetFishName()
    {
        return this._fishName;
    }

    public string GetDescription()
    {
        return this._description;
    }

    public FishSize GetFishSize()
    {
        return _fishSize;
    }

    public int Strength
    {
        get
        {
            switch (_fishSize)
            {
                case FishSize.Tiny:
                    return 1;
                case FishSize.Small:
                    return 3;
                case FishSize.Medium:
                    return 5;
                case FishSize.Large:
                    return 7;
                default:
                    return 1;
            }
        }
    }

    public Sprite FishIcon
    {
        get
        {
            return _icon;
        }
    }
}
