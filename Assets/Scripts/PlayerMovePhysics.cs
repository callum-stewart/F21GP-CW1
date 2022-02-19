using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePhysics : MonoBehaviour
{
    //public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    public float maxFloorSlope = 35f;

    Vector3 velocityCurrentDirection = Vector3.zero;
    Vector3 currentDirection = Vector3.zero;

    Vector3 velocity;
    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //       isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //       Debug.Log(isGrounded);

        if (isGrounded && velocityCurrentDirection.y < 0)
        {
            velocityCurrentDirection.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * Time.deltaTime + transform.forward * z * Time.deltaTime;
        //controller.Move(move * speed * Time.deltaTime);
        transform.Translate(move);

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}

        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
        //Debug.Log(velocity.y);
    }

    private bool isFlat(Vector3 vec)
    {
        return Vector3.Angle(Vector3.up, vec) < maxFloorSlope;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter");
        foreach (ContactPoint cp in collision.contacts)
        {
            if (isFlat(cp.normal))
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
        return;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit");
        foreach (ContactPoint cp in collision.contacts)
        {
            if (isFlat(cp.normal))
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
        return;
    }
}
