using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishFactory
{
    [SerializeField]
    private CaughtFish tiny;
    [SerializeField]
    private CaughtFish small;
    [SerializeField]
    private CaughtFish medium;
    [SerializeField]
    private CaughtFish large;
    [SerializeField]
    private CaughtFish huge;
    [SerializeField]
    private CaughtFish gigantic;

    public FishFactory()
    {

    }

    public Fish CreateFish(FishPool fishPool)
    {
        FishSize newFishSize = fishPool.RandomFishSize;
        Fish fish = new Fish(newFishSize, GetFishTemplate(newFishSize));
        return fish;
    }

    private CaughtFish GetFishTemplate(FishSize bySize)
    {
        switch (bySize)
        {
            case FishSize.Tiny:
                return tiny;
            case FishSize.Small:
                return small;
            case FishSize.Medium:
                return medium;
            case FishSize.Large:
                return large;
            case FishSize.Huge:
                return huge;
            case FishSize.Gigantous:
                return gigantic;
            default:
                return tiny;
        }
    }
}
