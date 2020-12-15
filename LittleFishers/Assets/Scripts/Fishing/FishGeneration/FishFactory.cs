using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishFactory
{
    string[] names = new string[] {
            "Angelfish",
            "JellyFish",
            "Anthias",
            "Bassandgroupers",
            "Bassletsandassessors",
            "Batfish",
            "Blennies",
            "Boxfishandblowfish",
            "Butterflyfish",
            "Cardinalfish",
            "Chromis",
            "Clownfish",
            "Damsels",
            "Dartfish",
            "Dragonets",
            "Eels",
            "Filefish",
            "Foxface",
            "Flatfish",
            "Frogfish",
            "Goatfish",
            "Gobies",
            "Grunts",
            "Hamlet",
            "Hawkfish",
            "Scorpionfish",
            "Seahorse",
            "Squirrelfish",
            "Sharks",
            "Snappers",
            "Tangs",
            "Tilefish",
            "Triggerfish",
            "Wrasse" };

    public FishFactory()
    {

    }

    public Fish CreateFish(FishPool fishPool)
    {
        Sprite fishIcon = Resources.Load<Sprite>(FishIcon(FishSize.Tiny));

        Array fishSizeArray = Enum.GetValues(typeof(FishSize));
        FishSize randomFishSize = (FishSize)UnityEngine.Random.Range(0, fishSizeArray.Length);

        Fish fish = new Fish(randomFishSize, GetRandomFishName(), "", fishIcon);
        return fish;
    }

    private string GetRandomFishName()
    {
        return names[UnityEngine.Random.Range(0, names.Length - 1)];
    }

    private string FishIcon(FishSize fishSize)
    {
        switch (fishSize)
        {
            case FishSize.Tiny:
                return "Sprites/Fishing/fisu";
            default:
                return "Sprites/Fishing/fisu";
        }
    }
}
