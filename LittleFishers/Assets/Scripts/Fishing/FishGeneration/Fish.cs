using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish
{
    private FishSize fishSize;
    private string fishName;
    [TextArea(15, 20)]
    private string description;

    public Fish(FishSize _fishSize, string _fishName, string _description)
    {
        fishName = _fishName;
        fishSize = _fishSize;
        description = _description;
    }

    public string GetFishName()
    {
        return this.fishName;
    }

    public string GetDescription()
    {
        return this.description;
    }

    public FishSize GetFishSize()
    {
        return fishSize;
    }

    public int GetFishStrength()
    {
        switch (fishSize)
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

    private Sprite GetFishIcon()
    {
        string fishIconName = "FishTiny";
        switch (this.fishSize)
        {
            case FishSize.Tiny:
                fishIconName = "FishTiny";
                break;
            case FishSize.Small:
                fishIconName = "FishSmall";
                break;
            case FishSize.Medium:
                fishIconName = "FishMedium";
                break;
            case FishSize.Large:
                fishIconName = "FishLarge";
                break;
            default:
                fishIconName = "FishTiny";
                break;
        }
        return (Sprite)Resources.Load<Sprite>("Sprites/Fishing/" + fishIconName);
    }

    public Sprite FishIcon
    {
        get
        {
            return GetFishIcon();
        }
    }
}
