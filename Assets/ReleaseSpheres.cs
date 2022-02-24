using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseSpheres : MonoBehaviour
{
    [SerializeField]
    Rigidbody[] spheres;

    bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            foreach (Rigidbody sphere in spheres)
            {
                sphere.useGravity = true;
            }
        }
    }

}
