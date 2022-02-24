using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPendulum : MonoBehaviour
{
    public float maxDeflectionAngle = 30.0f;
    public float pendulumSpeed = 10.0f;
    public float deflectionAngle { get; set; }
    public float swingDirection = 0;
    private float previousAngle = 0;
    private Rigidbody weightRb;

    private void Start()
    {
        weightRb = GetComponentInChildren<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        previousAngle = deflectionAngle;
        deflectionAngle = maxDeflectionAngle * Mathf.Sin(Time.time * pendulumSpeed);
        swingDirection = deflectionAngle - previousAngle;

        transform.localRotation = Quaternion.Euler(0, 0, deflectionAngle);
        //Debug.Log(swingDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
        {
            Debug.Log("contact with plater");
            Rigidbody rb = collision.collider.attachedRigidbody;
            rb.AddForce(weightRb.velocity.normalized * 1000);
        }
    }
}
