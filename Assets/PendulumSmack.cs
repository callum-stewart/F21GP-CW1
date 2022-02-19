using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumSmack : MonoBehaviour
{
    private Vector3 currentDirection;
    private Vector3 currentPosition;
    private Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        previousPosition = currentPosition;
        currentPosition = transform.position;
        currentDirection = (currentPosition - previousPosition).normalized;

    }

    private void OnTriggerEnter(Collider other)
    {
        //sDebug.Log("onTriggerEnter triggered");
        if (other.attachedRigidbody != null)
        {
            Debug.Log("velocity (x,y,z): (" + currentDirection.x +","+currentDirection.y+","+currentDirection.z+")");
        }
    }
}
