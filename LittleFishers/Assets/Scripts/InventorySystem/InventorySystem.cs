using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private InventoryObjectFactory inventoryObjectFactory;

    [SerializeField]
    private InventoryTemplate dafaultPlayerInventory;
    [SerializeField]
    private InventoryTemplate dafaultHutInventory;

    void Awake()
    {
        this.inventoryObjectFactory = new InventoryObjectFactory();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public InventoryObject GetNewInventoryObject(ItemObject itemObject)
    {
        return inventoryObjectFactory.CreateNewInventoryObject(itemObject);
    }

    public static Inventory CreateNewInventoryBasedOn(InventoryTemplate inventoryTemplate)
    {
        Inventory newInventory = new Inventory(inventoryTemplate);
        return newInventory;
    }
}
