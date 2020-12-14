using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    public float throwDistance;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<LimitedValue>().SetValue(-15);
    }

    public void StartFishing(Vector3 position)
    {
        Debug.Log("Start Fishing at " + position.ToString());
    }
}
