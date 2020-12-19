using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public delegate void OnLevelChanged(int from, int to);

public class LevelTrack : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;

    void Awake()
    {

    }

    void Start()
    {
        label.text = "1";
    }

    public void OnLevelChanged(int from, int to)
    {
        label.text = to.ToString();
    }
}
