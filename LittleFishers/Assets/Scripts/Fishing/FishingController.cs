using UnityEngine;
using LittleFishers.Fishing;

public class FishingController : MonoBehaviour
{

    public GameObject _fishingTargetPrefab;
    public float throwDistance;

    private Fishing _fishing;


    void Awake()
    {
        _fishing = new Fishing();
    }

    private void Update()
    {
        _fishing.Tick();
    }

    public void SetFishingIndicator(Player player, bool visible)
    {
        player.FishingIndicator.SetActive(visible);
    }

    public void StartFishing(Vector3 position, FishPool fishPool, Player player)
    {
        /*
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
        */
    }

    private bool CanPlayerCatchFish(Fish fish, PlayerStats playerStats)
    {
        return fish.Strength <= playerStats.GetPlayerStrength();
    }
}
