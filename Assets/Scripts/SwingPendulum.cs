using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPendulum : MonoBehaviour
{
    public float maxDeflectionAngle = 30.0f;
    public float pendulumSpeed = 10.0f;


    // Update is called once per frame
    void Update()
    {
        float angle = maxDeflectionAngle * Mathf.Sin(Time.time * pendulumSpeed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }


}
