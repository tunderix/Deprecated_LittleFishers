using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    int something = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Happened½");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 some = new Vector3();
        
    }

    private void Awake() {
        Debug.Log("This happened first " + something);
    }
}
