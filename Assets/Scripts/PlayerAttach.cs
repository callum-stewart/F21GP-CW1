using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    public GameObject playerController;

    private void Start()
    {
        //playerController = FindObjectOfType<PlayerMovementController>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController)
        {
            playerController.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController)
        {
            playerController.transform.parent = null;
        }
    }
}
