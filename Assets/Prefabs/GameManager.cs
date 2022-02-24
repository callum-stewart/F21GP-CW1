using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> lemmings = new List<GameObject>();
    public int maxDeadLemmings = 3;
    public int lemmingCount;
    private bool isGameOver = false;
    public enum EndGameState {AT_FINISH_LINE, FELL, LEMMINGS_LEFT_BEHIND, TOO_MANY_DEAD_LEMMINGS};
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject lemming in GameObject.FindGameObjectsWithTag("slime"))
        {
            lemmings.Add(lemming);
        }
        lemmingCount = lemmings.Count;

        Debug.Log("[GameManager] Number of slimes: " + lemmings.Count);
    }

    private void Update()
    {
        if ((lemmingCount - lemmings.Count) >= maxDeadLemmings)
        {
            GameOver(EndGameState.TOO_MANY_DEAD_LEMMINGS);
        }
    }

    // fail conditions:
    //   you reach the end with less than the required lemmings
    //   a turtleshell kills too many lemmings
    //   you fall off of something
    public void GameOver(EndGameState gameState)
    {
        if (!isGameOver)
        {
            bool hasFailed = false;
            isGameOver = true;

            if (gameState == EndGameState.TOO_MANY_DEAD_LEMMINGS ||
                gameState == EndGameState.FELL)
            {
                GameFail(gameState);
                return;
            }

            foreach (GameObject lgo in lemmings)
            {
                LemmingController lc = lgo.GetComponent<LemmingController>();
                if (lc.LemmingState != LemmingController.State.FOLLOWING) // are there lemmings left behind?
                {
                    hasFailed = true;
                    GameFail(EndGameState.LEMMINGS_LEFT_BEHIND);
                    return;
                }
            }
            if (!hasFailed)
            {
                GameWin();
                return;
            }
        }
    }

    private void GameFail(EndGameState gameState)
    {
        if (gameState == EndGameState.FELL)
        {
            Debug.Log("You fell and died!");
        } else if (gameState == EndGameState.TOO_MANY_DEAD_LEMMINGS)
        {
            Debug.Log("Too many lemmings died!");
        } else if (gameState == EndGameState.LEMMINGS_LEFT_BEHIND)
        {
            Debug.Log("You left too many lemmings behind!");
        }
    }

    private void GameWin()
    {
        Debug.Log("You win!");
    }
}
