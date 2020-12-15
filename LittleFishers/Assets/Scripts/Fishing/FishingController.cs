using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FishingController : MonoBehaviour
{
    public float throwDistance;

    private FishFactory fishFactory;

    [SerializeField]
    private ItemObject tinyFishObject;

    void Awake()
    {
        fishFactory = new FishFactory();
    }

    public void StartFishing(Vector3 position, FishPool fishPool, Player player)
    {
        Fish fish = fishFactory.CreateFish(fishPool);
        PlayerStats stats = player.GetPlayerStats();
        Inventory inventory = player.GetPlayerInventory();

        bool canPlayerCatchFish = CanPlayerCatchFish(fish, stats);

        Debug.Log("Start Fishing :: Fish is " + fish.GetFishName() + ", CaughtFish: " + canPlayerCatchFish + "::: " + fish.GetFishStrength() + "vs" + player.GetPlayerStats().GetPlayerStrength());

        if (canPlayerCatchFish)
        {
            stats.AddExperience(2);
            inventory.AddItem(tinyFishObject, 1);
        }
    }

    private bool CanPlayerCatchFish(Fish fish, PlayerStats playerStats)
    {
        bool catchFish = false;

        if (fish.GetFishStrength() <= playerStats.GetPlayerStrength())
        {
            catchFish = true;
        }

        return catchFish;
    }
}
