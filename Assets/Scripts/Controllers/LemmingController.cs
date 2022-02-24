using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LemmingController : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public enum State {PATROLLING, FOLLOWING, ABANDONDED };
    public State LemmingState { get; set; }
    State PrevState;
    float playerDist;
    int nextDest = 0;
    float followRangeSqr;
    bool hasFollowed = false; //if i've ever follwed the player, don't go back to patrolling
                      //just sit still
    FollowPoint currentFollowPoint;



    public GameObject[] patrolPoints;
    List<FollowPoint> followPoints = new List<FollowPoint>();
    public float followRange;
    public float followSpeed;
    public float patrolSpeed;



    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("player")[0];
        agent = transform.GetComponent<NavMeshAgent>();
        GameObject[] followPointGOs = GameObject.FindGameObjectsWithTag("followPoint");
        foreach (GameObject fpgo in followPointGOs)
        {
            FollowPoint fp = fpgo.GetComponent<FollowPoint>();
            followPoints.Add(fp);
        }
        followRangeSqr = followRange * followRange;
        currentFollowPoint = null;

        //playerDist = Vector3.Distance(transform.position, player.transform.position);
        agent.autoBraking = false;
        //state = (playerDist <= followRange) ? State.FOLLOWING : State.PATROLLING;
        LemmingState = State.PATROLLING;
        GoToNextPatrolPoint();
        //if (state == State.PATROLLING && patrolPoints.Length > 0)
        //{
        //    GoToNextPatrolPoint();

        //}
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        //agent.destination = patrolPoints[nextDest++].transform.position;
        //nextDest %= patrolPoints.Length;
    }

    void Patrol()
    {
        agent.speed = patrolSpeed;
        if (patrolPoints.Length > 0)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {

                GoToNextPatrolPoint();
            }
        } else
        {
            agent.SetDestination(transform.position);
        }
    }

    void Follow()
    {
        //Debug.Log("followPoint: " + currentFollowPoint);
        hasFollowed = true;
        agent.autoBraking = true;
        agent.speed = followSpeed;

        //state change to following, need to set a follow point
        if (currentFollowPoint == null)
        {
            //Debug.Log("Reached");
            LemmingState = State.FOLLOWING;
            foreach (FollowPoint fp in followPoints)
            {
                //Debug.Log("isOccupied:" + fp.isOccupied);
                if (!fp.isOccupied)
                {
                    currentFollowPoint = fp;
                    fp.isOccupied = true;
                    break;
                }
            }
        }
        agent.SetDestination(currentFollowPoint.transform.position);
    }

    void Abandoned()
    {
        if (currentFollowPoint != null)
        {
            currentFollowPoint.isOccupied = false;
            currentFollowPoint = null;
        }
        agent.SetDestination(transform.position);
    }

    void Update()
    {
        //Debug.Log(state);
        Vector3 offset = transform.position - player.transform.position;
        // using square magnitude to avoid sqrt performance penalties 
        playerDist = offset.sqrMagnitude;
        //Debug.Log("hasFollowed:" + hasFollowed);
        //Debug.Log("playerDist<=followRangeSqr" + (playerDist <= followRangeSqr));
        //PrevState = LemmingState;
        LemmingState = (playerDist <= followRangeSqr)
            ? State.FOLLOWING
            :(hasFollowed)
            ? State.ABANDONDED 
            : State.PATROLLING;

     switch (LemmingState)
        {
            case (State.PATROLLING):
                Patrol();
                break;
            case (State.FOLLOWING):
                Follow();
                break;
            case (State.ABANDONDED):
                Abandoned();
                break; 
        }
    }
}
