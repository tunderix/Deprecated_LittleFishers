using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Selectable : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionIndicator;

    [SerializeField]
    private bool isSelected;

    public bool IsSelected
    {
        get
        {
            return this.isSelected;
        }
        set
        {
            this.isSelected = value;
            selectionIndicator.gameObject.SetActive(isSelected);
        }
    }

    void Start()
    {
        IsSelected = false;
    }
}
