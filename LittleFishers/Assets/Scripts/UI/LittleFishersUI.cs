using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFishersUI : MonoBehaviour
{
    [SerializeField]
    private Backpack backpack;

    public void UpdateUI()
    {
        backpack.UpdateBackpack();
    }
}
