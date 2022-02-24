using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumSmack : MonoBehaviour
{
    Rigidbody weightRb;
    SwingPendulum parent;
    public int forceOfImpact = 100;
    // Start is called before the first frame update
    void Start()
    {
        weightRb = GetComponent<Rigidbody>();
        parent = GetComponentInParent<SwingPendulum>();
    }

    private void Update()
    {
       //Debug.Log("parent angle: " + parent.deflectionAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        //sDebug.Log("onTriggerEnter triggered");
        if (other.attachedRigidbody != null)
        {
            int direction = (parent.swingDirection > 0) ? 1 : -1;
            other.attachedRigidbody.AddForce(transform.right * direction * forceOfImpact, ForceMode.Impulse);
            //Vector3 playerVelocity = other.attachedRigidbody.velocity;
            //other.attachedRigidbody.velocity = new Vector3(playerVelocity.x + (forceOfImpact*direction), playerVelocity.y, playerVelocity.z);
            Debug.Log("ball going: " + ((parent.swingDirection > 0) ? "left" : "right"));
        }
    }
}
