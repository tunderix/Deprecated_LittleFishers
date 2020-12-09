using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMovement : MonoBehaviour
{

    Vector3 newPosition;
    public float speed;
    public float walkRange;

    void Start()
    {
        newPosition = this.transform.position;
    }

    public void MoveTo(Vector3 target)
    {
        newPosition = target;
        this.GetComponentInChildren<NavMeshAgent>().SetDestination(newPosition);
    }
}