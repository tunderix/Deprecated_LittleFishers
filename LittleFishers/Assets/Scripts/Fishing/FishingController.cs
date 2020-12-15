using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FishingController : MonoBehaviour
{
    public float throwDistance;

    private FishFactory fishFactory;
    [SerializeField]

    void Awake()
    {
        fishFactory = new FishFactory();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<LimitedValue>().SetValue(-15);
    }

    public void StartFishing(Vector3 position, FishPool fishPool, Player player)
    {
        Fish fish = fishFactory.CreateFish(fishPool);
        PlayerStats stats = player.GetPlayerStats();
        Inventory inventory = player.GetPlayerInventory();

        bool canPlayerCatchFish = CanPlayerCatchFish(fish, stats);

        //inventory.AddItem(fish)
        Debug.Log("Start Fishing :: Fish is " + fish.GetFishName() + ", CaughtFish: " + canPlayerCatchFish + "::: " + fish.GetFishStrength() + "vs" + player.GetPlayerStats().GetPlayerStrength());

        if (canPlayerCatchFish)
        {
            //inventory.AddItem(fish)
            stats.AddExperience(2);
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
