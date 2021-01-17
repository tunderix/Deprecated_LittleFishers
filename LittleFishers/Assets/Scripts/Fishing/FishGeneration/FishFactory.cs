using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishFactory
{

    public FishFactory()
    {

    }

    public Fish CreateFish(FishSize newFishSize)
    {
        Fish fish = new Fish(newFishSize);
        return fish;
    }
}
