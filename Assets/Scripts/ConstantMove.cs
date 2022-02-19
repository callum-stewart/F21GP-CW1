using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public float boxSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curpos = transform.position;
        transform.position = curpos - Vector3.right * boxSpeed * Time.deltaTime;
    }
}
