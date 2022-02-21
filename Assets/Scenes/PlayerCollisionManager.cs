using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerMovementController playerMovementController;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerMovementController = GetComponent<PlayerMovementController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "endgame_waypoint")
        {
            playerMovementController.enabled = false;
            gameManager.GameOver(GameManager.EndGameState.AT_FINISH_LINE);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
