using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackpackSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countLabel;
    private BackpackInventoryItem _backpackInventoryItem;
    public void SetBackpackInventoryItem(BackpackInventoryItem backpackInventoryItem)
    {
        _backpackInventoryItem = backpackInventoryItem;
    }

    public void UpdateInventoryItemPosition()
    {
        _backpackInventoryItem.transform.position = this.transform.position;
    }
}
