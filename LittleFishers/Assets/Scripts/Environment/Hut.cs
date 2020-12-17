using UnityEngine;

public class Hut : MonoBehaviour
{
    private Player localplayer;
    [SerializeField]
    private ItemObject itemToGivePlayer;

    [SerializeField]
    private Inventory HutInventory;

    [SerializeField]
    private GameObject ShopLayout;

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Approached Hut");
        ShopLayout.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Left Hut");
        ShopLayout.SetActive(false);
    }

    public void SetHutInventory(Inventory inventory)
    {
        this.HutInventory = inventory;
    }
}
