using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    public float jumpPadForce = 12f;
    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log(other.gameObject.GetComponent<Rigidbody>());
        Debug.Log("triggered");
        //Debug.Log(other.attachedRigidbody);
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPadForce, ForceMode.Impulse);
    }
}
