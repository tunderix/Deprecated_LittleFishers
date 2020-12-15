using UnityEngine;

public class Hut : MonoBehaviour
{
    private Player localplayer;
    [SerializeField]
    private ItemObject itemToGivePlayer;

    void Update()
    {
        if (localplayer)
            localplayer.GetPlayerInventory().AddItem(itemToGivePlayer, 1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            localplayer = other.GetComponent<Player>();
        Debug.Log("Player Approached Hut");
    }
}
