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
    private int _goldValue;

    public Fish(FishSize fishSize, CaughtFish caughtFish)
    {
        this._fishSize = fishSize;
        this._fishName = FishingHelper.RandomFishName;
        this._fishSizeName = caughtFish.name;
        this._description = caughtFish.description;
        this._icon = caughtFish.backpackIcon;
        this._goldValue = decideGoldValue(caughtFish.minGoldValue, caughtFish.maxGoldValue);
    }

    private int decideGoldValue(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }


    public string FishName
    {
        get
        {
            return this._fishName;
        }
    }

    public string Description
    {
        get
        {
            return this._description;
        }
    }

    public FishSize Size
    {
        get
        {
            return this._fishSize;
        }
    }

    public string Value
    {
        get
        {
            return this._fishName;
        }
    }

    public int GoldValue
    {
        get
        {
            return this._goldValue;
        }
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
                case FishSize.Huge:
                    return 9;
                case FishSize.Gigantous:
                    return 11;
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

    public int ExperienceBySize
    {
        get
        {
            switch (_fishSize)
            {
                case FishSize.Tiny:
                    return 1;
                case FishSize.Small:
                    return 2;
                case FishSize.Medium:
                    return 3;
                case FishSize.Large:
                    return 4;
                case FishSize.Huge:
                    return 5;
                case FishSize.Gigantous:
                    return 6;
                default:
                    return 1;
            }
        }
    }
}
