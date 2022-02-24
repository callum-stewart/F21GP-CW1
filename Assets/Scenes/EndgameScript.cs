using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameScript : MonoBehaviour
{
    private PlayerMovementController player;
    private GameManager gameManager;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovementController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            gameManager.GameOver(GameManager.EndGameState.AT_FINISH_LINE);
        }
    }
}
