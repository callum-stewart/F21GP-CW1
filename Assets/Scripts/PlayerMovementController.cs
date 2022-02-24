using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float maxFallSpeed = -20; // Go faster than this and it is game over due to falling

    private Rigidbody body;
    private float vertical;
    private float horizontal;
    private bool isGrounded;
    
    private bool isOnPlatform;
    private Rigidbody platform;
    private GameManager gameManager;

    void Start()
    {
        // Obtain the reference to our Rigidbody.
        body = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

    }
    // Fixed Update is called a fix number of frames per second.
    void LateUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        //Debug.Log("isGrounded: " + isGrounded);
        //Debug.Log("isOnPlatform:" + isOnPlatform);
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                body.AddForce(transform.up * jumpForce);
            }
        }
        Vector3 velocity = ((transform.forward * vertical) + (transform.right * horizontal)) * speed * Time.fixedDeltaTime;
        velocity.y = body.velocity.y;
        if (isOnPlatform)
        {
            velocity.x += platform.velocity.x;
        }
        body.velocity = velocity;
        if (velocity.y <= maxFallSpeed)
        {
            gameManager.GameOver(GameManager.EndGameState.FELL);
        }

    }
    // This function is a callback for when an object with a collider collides with this objects collider.
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("onTriggerEnter entered: " + collision.gameObject.name);
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "moving_platform")
        {
            isOnPlatform = true;
            isGrounded = true;
            platform = collision.collider.attachedRigidbody;
        }
    }
    // This function is a callback for when the collider is no longer in contact with a previously collided object.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "moving_platform")
        {
            isOnPlatform = false;
            isGrounded = false;
            platform = null;
        }
    }
}
