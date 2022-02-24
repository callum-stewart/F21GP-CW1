using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    public GameObject playerController;
    PlayerMovementController playerMovementController;
    Rigidbody playerControllerRb;
    Rigidbody platformRb;
    Vector3 offset;
    bool playerOn;

    private void Start()
    {
        platformRb = GetComponent<Rigidbody>();
        playerMovementController = playerController.GetComponent<PlayerMovementController>();
        playerController = playerMovementController.gameObject;
        playerControllerRb = playerController.GetComponent<Rigidbody>();
        playerOn = false;
    }

    private void LateUpdate()
    {
        if (playerOn)
        {
            Debug.Log("here");
            playerController.transform.position = transform.position + offset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController)
        {
            playerOn = true;
            Debug.Log("landed on platform");
            //playerController.transform.parent = transform;
            playerControllerRb.detectCollisions = false;
            playerControllerRb.isKinematic = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        offset = other.transform.position - transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController)
        {
            playerOn = false;
            //playerController.transform.parent = null;
            playerControllerRb.detectCollisions = true;
            playerControllerRb.isKinematic = false;
        }
    }
}

