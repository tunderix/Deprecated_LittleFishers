using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnExperienceAmountChanged(float from, float to);

public class ExperienceTrack : MonoBehaviour
{
    private Slider _slider;

    [SerializeField]
    private bool debug;

    void Awake()
    {
        this._slider = GetComponentInChildren<Slider>();
    }

    void Start()
    {
        this._slider.value = 0;
    }

    public void playerExperienceAmountChanged(float from, float to)
    {
        if (this._slider != null)
            this._slider.value = to;
        if (debug)
            Debug.Log("Exp Changed :: (FROM: " + from + ") --> (TO: " + to + ")");
    }
}
