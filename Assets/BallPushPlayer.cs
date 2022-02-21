using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPushPlayer : MonoBehaviour
{
    public GameObject playerController;
    PlayerMovementController playerMovementController;
    Vector3 playerVeloctiy;
    Rigidbody playerControllerRb;
    Rigidbody sphereRb;

    private void Start()
    {

        playerMovementController = playerController.GetComponent<PlayerMovementController>();
        playerController = playerMovementController.gameObject;
        playerControllerRb = playerController.GetComponent<Rigidbody>();
        playerVeloctiy = playerMovementController.velocity;
        sphereRb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController)
        {
            playerControllerRb.AddForce(50 * sphereRb.velocity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController)
        {
            //playerController.transform.parent = null;
            //playerControllerRb.detectCollisions = true;
            //playerControllerRb.isKinematic = false;
            //playerMovementController.gravity = -9.81f;
        }
    }
}
