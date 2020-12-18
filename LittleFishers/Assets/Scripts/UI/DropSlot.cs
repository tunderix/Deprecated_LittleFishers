using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //subscribe on Backpack
    public event BackpackItemDroppedDelegate OnBackpackItemDroppedOn;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            OnBackpackItemDroppedOn(d.startParent.GetComponent<BackpackSlot>(), GetComponent<BackpackSlot>());
            d.startParent = this.transform;
            d.transform.position = new Vector2(0, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
