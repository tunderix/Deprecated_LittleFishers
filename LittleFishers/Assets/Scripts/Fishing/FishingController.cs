using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FishingController : MonoBehaviour
{
    public float throwDistance;

    private FishFactory fishFactory;

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

        Debug.Log("Start Fishing :: FishName: " + fish.GetFishSize() + ", CaughtFish: " + canPlayerCatchFish);

        if (canPlayerCatchFish)
        {
            stats.AddExperience(2);
            InventoryObject fishInventoryObject = new InventoryObject(fish.GetFishName(), fish.GetDescription(), 2, 1, fish.FishIcon);
            bool collectedCollectable = inventory.AddItem(fishInventoryObject);
            Debug.Log(collectedCollectable ? "Success for inventoryplacement" : "Failure for inventoryplacement");
        }
    }

    private bool CanPlayerCatchFish(Fish fish, PlayerStats playerStats)
    {
        return fish.Strength <= playerStats.GetPlayerStrength();
    }
}
