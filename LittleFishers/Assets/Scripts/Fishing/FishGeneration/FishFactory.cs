using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishFactory
{

    public FishFactory()
    {

    }

    public Fish CreateFish(FishSize newFishSize, CaughtFish fishTemplate)
    {
        Fish fish = new Fish(newFishSize, fishTemplate);
        return fish;
    }
}
