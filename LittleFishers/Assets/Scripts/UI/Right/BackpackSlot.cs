using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackSlot : MonoBehaviour
{
    [SerializeField]
    private ItemObject itemObject;

    public void SetItem(ItemObject _itemObject)
    {
        this.itemObject = _itemObject;
        this.GetComponentInChildren<Image>().enabled = true;
        this.GetComponentInChildren<Image>().sprite = itemObject.backpackIcon;
    }
}
