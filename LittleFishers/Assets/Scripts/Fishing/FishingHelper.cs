
using UnityEngine;
using UnityEditor;

public class FishingHelper
{
    public static int calculateFishExperience(FishPool pool, Fish fish, PlayerStats stats)
    {
        int experienceGained = 0;
        experienceGained += fish.ExperienceBySize;

        // TODO Limit exprience by pool modifiers
        //experienceGained -= pool.ExperiencePenaltyModifier(stats.Experience.PlayerLevel);

        if (experienceGained < 1) experienceGained = 1;

        return experienceGained;
    }

    public static bool canStartFishing(float throwRange, Vector3 playerPosition, Vector3 targetFishingPosition, GameObject clickedGO)
    {
        float throwDistance = Vector3.Distance(playerPosition, targetFishingPosition);
        return (clickedGO.tag == "Water" && throwDistance < throwRange);
    }

    public static CaughtFish fishObjectBySize(FishSize size)
    {
        switch (size)
        {
            default:
                return (CaughtFish)ScriptableObject.CreateInstance(typeof(CaughtFish));
        }
    }

    public static string RandomFishName
    {
        get
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
            return names[UnityEngine.Random.Range(0, names.Length - 1)];
        }
    }
}
