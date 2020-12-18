using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeighingInventory : MonoBehaviour
{
    [SerializeField]
    private int weighingSlots = 14;

    [SerializeField]
    private GameObject weighingSlotPrefab;

    void Start()
    {
        for (int i = 0; i < 14; i++)
        {
            GameObject slot = GameObject.Instantiate(weighingSlotPrefab, weighingSlotPrefab.transform.position, Quaternion.identity);
            slot.transform.SetParent(this.transform);
            WeighingSlot weighingSlot = slot.GetComponent<WeighingSlot>();
            if (weighingSlot != null)
            {
                weighingSlot.slotIndex = i;
            }
        }
    }
}
