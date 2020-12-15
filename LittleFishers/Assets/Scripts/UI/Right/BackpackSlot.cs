using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackpackSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countLabel;
    [SerializeField]
    private Image imageComponent;

    public void SetItem(ItemObject _itemObject, int amount)
    {
        if (_itemObject)
        {
            countLabel.SetText(amount.ToString());
            imageComponent.enabled = true;
            imageComponent.sprite = _itemObject.backpackIcon;
        }

    }
}
