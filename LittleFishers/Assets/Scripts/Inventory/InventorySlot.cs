using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.LFInventory
{
    public class InventorySlot
    {
        private int _slotId;
        public InventorySlot(int slotId)
        {
            _slotId = slotId;
        }
        public int SlotID { get => this._slotId; }
    }
}
