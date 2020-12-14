using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedValue : MonoBehaviour 
{
    [SerializeField]
    private int minValue; 
    [SerializeField]
    private int maxValue;

    [SerializeField]
    [Range(0, 100)]
    private int value; 
    
    public void SetValue(int newValue){
        this.value = SetAndValidateValue(newValue);
    }

    private int SetAndValidateValue(int newValue)
    {
        if (newValue < minValue) return minValue;
        if (newValue > maxValue) return maxValue;
        return newValue;
    }
}
