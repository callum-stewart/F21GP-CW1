using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    List<Transform> targets = new List<Transform>();
    Transform currTarget;
    GameManager gameManager;
    public GameObject dest;
    public float lookRadius = 50f;
    public float killRadius = 4f;
    LivesLeft lifeBar;
    public static int killCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        foreach (GameObject slm in GameObject.FindGameObjectsWithTag("slime"))
        {
            targets.Add(slm.transform);
        }
        Debug.Log("number of targets: " + targets.Count);
        if (targets.Count > 0)
        {
            getNextTarget();
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lifeBar = GameObject.Find("Lives").GetComponent<LivesLeft>();
        Debug.Log("lifeBar: " + lifeBar.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0 && currTarget != null)
        {

            agent.SetDestination(currTarget.position);
            if (Vector3.Distance(currTarget.position, transform.position) < killRadius)
            {
                killTarget(currTarget);
                if (targets.Count > 0)
                {
                    getNextTarget(); //placeholder, target will be recalculated later
                }
                else
                {
                    currTarget = null;
                }
            }
        }
    }

    private void getNextTarget()
    {
        if (targets.Count <= 0)
        {
            return;
        }
        currTarget = targets[0];
        foreach (Transform target in targets)
        {
            if (Vector3.Distance(transform.position, target.position) < Vector3.Distance(transform.position, currTarget.position))
            {
                currTarget = target;
            }
        }
        Debug.Log("current target: " + currTarget.name);
    }

    private void killTarget(Transform currTarget)
    {
        targets.Remove(currTarget);
        gameManager.lemmings.Remove(currTarget.gameObject);
        Debug.Log("Lemming GO: " + currTarget.gameObject);
        Destroy(currTarget.gameObject, 2f);
        lifeBar.removeLife();
        EnemyController.killCount++;
        if (killCount >= 3)
        {
            gameManager.GameOver(GameManager.EndGameState.TOO_MANY_DEAD_LEMMINGS);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
