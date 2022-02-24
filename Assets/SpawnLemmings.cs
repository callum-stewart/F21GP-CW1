using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnLemmings : MonoBehaviour
{
    [SerializeField]
    GameObject lemmingPrefab;
    [SerializeField]
    float maxDist;
    [SerializeField]
    Vector3 center;
    GameManager gameManager;

    List<(GameObject, Vector3, Vector3)> lemmings;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> startPositions = new List<Vector3>();
        lemmings = new List<(GameObject, Vector3, Vector3)>();
        gameManager = FindObjectOfType<GameManager>();
        //List<(Vector3, Vector3)> patrolPoints = new List<(Vector3, Vector3)>();
        for (int i = 0; i<11; i++)
        {
            startPositions.Add(getRandomPoint(center, maxDist));
        }

        foreach (Vector3 startPosition in startPositions)
        {
            GameObject e = Instantiate(lemmingPrefab, startPosition, Quaternion.Euler(0, 0, 0));
            e.SetActive(true);
            gameManager.lemmings.Add(e);
            //LemmingController lc = e.GetComponent<LemmingController>();
            //lc.patrolPoints[0] = getRandomPoint(center, maxDist);
            //lc.patrolPoints[1] = getRandomPoint(center, maxDist);
        }

        gameManager.lemmingCount = lemmings.Count;
    }

    public static Vector3 getRandomPoint(Vector3 center, float maxDist)
    {
        Vector3 random = maxDist * Random.insideUnitSphere + center;
        NavMeshHit point;

        NavMesh.SamplePosition(random, out point, maxDist, NavMesh.AllAreas);
        return point.position;
    }
}
