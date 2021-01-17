using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FishingController : MonoBehaviour
{

    public GameObject _fishingTargetPrefab;
    public float throwDistance;

    private FishFactory fishFactory;

    void Awake()
    {
        fishFactory = new FishFactory();
    }

    public void StartFishing(Vector3 position, FishPool fishPool, Player player)
    {
        FishSize newFishSize = fishPool.RandomFishSize;
        Fish fish = fishFactory.CreateFish(newFishSize);
        PlayerStats stats = player.GetPlayerStats();

        GameObject fishingTargetPrefab = GameObject.Instantiate(_fishingTargetPrefab, position, Quaternion.identity);
        FishingTarget fishingTarget = fishingTargetPrefab.GetComponent<FishingTarget>();
        if (fishingTarget != null)
        {

        }

        bool canPlayerCatchFish = CanPlayerCatchFish(fish, stats);
        Debug.Log("Start Fishing :: FishName: " + fish.Size + ", CaughtFish: " + canPlayerCatchFish);
        if (canPlayerCatchFish)
        {
            stats.AddExperience(FishingHelper.calculateFishExperience(fishPool, fish, stats));
        }
    }

    private bool CanPlayerCatchFish(Fish fish, PlayerStats playerStats)
    {
        return fish.Strength <= playerStats.GetPlayerStrength();
    }
}
