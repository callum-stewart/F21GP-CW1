using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlingEnemyIntoAir : MonoBehaviour
{
    public float flingForce = 10f;
    Rigidbody _rb; 
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        Invoke("weee", 3);
        
    }

    void weee()
    {
        _rb.AddForce(Vector3.up * flingForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
