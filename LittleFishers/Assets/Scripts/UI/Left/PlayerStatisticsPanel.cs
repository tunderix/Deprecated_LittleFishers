using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerStatisticsPanel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            this.gameObject.SetActive(!this.gameObject.activeSelf);
        }
    }
}
