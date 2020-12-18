using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FishingController : MonoBehaviour
{
    public float throwDistance;

    [Header("Fish Templates")]
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

    private FishFactory fishFactory;

    void Awake()
    {
        fishFactory = new FishFactory();
    }

    public void StartFishing(Vector3 position, FishPool fishPool, Player player)
    {
        FishSize newFishSize = fishPool.RandomFishSize;
        Fish fish = fishFactory.CreateFish(newFishSize, GetFishTemplate(newFishSize));
        PlayerStats stats = player.GetPlayerStats();
        Inventory inventory = player.GetPlayerInventory();

        bool canPlayerCatchFish = CanPlayerCatchFish(fish, stats);
        Debug.Log("Start Fishing :: FishName: " + fish.Size + ", CaughtFish: " + canPlayerCatchFish);
        if (canPlayerCatchFish)
        {
            stats.AddExperience(FishingHelper.calculateFishExperience(fishPool, fish, stats));
            InventoryObject fishInventoryObject = new InventoryObject(fish);
            bool collectedCollectable = inventory.AddItem(fishInventoryObject);
            Debug.Log(collectedCollectable ? "Success for inventoryplacement" : "Failure for inventoryplacement");
        }
    }

    private bool CanPlayerCatchFish(Fish fish, PlayerStats playerStats)
    {
        return fish.Strength <= playerStats.GetPlayerStrength();
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
