using UnityEngine;
using LittleFishers.LFInventory;
using LittleFishers.UI;

namespace LittleFishers.Environment
{
    [RequireComponent(typeof(Visitable))]
    public class Hut : MonoBehaviour
    {

        [SerializeField] private UI_ShopLayout shopLayout;
        [SerializeField] private InventoryTemplate_Shop shopInventoryTemplate;
        [SerializeField] private InventoryTemplate_Weighing weighingInventoryTemplate;
        [SerializeField] private Backpack backpack;

        [SerializeField] private Inventory_Shop _shopInventory;
        [SerializeField] private Inventory_Weighing _weighingInventory;

        private Visitable visitable;

        private void Start()
        {
            visitable = this.GetComponent<Visitable>();

            //Subscribe to event for player coming in or going out
            visitable.OnVisitorArrived = VisitorCame;
            visitable.OnVisitorLeft = VisitorWent;

            _shopInventory = new Inventory_Shop(shopInventoryTemplate);
            _weighingInventory = new Inventory_Weighing(weighingInventoryTemplate);
        }

        private void VisitorCame()
        {
            Debug.Log("Visitor visiting Hut");
            shopLayout.gameObject.SetActive(true);
            shopLayout.UpdateContents(_shopInventory, _weighingInventory);
        }

        private void VisitorWent()
        {
            Debug.Log("Visitor left from Hut");
            shopLayout.gameObject.SetActive(false);
        }

    }
}