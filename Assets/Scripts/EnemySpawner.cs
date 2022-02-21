using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject player;
    public GameObject enemy;
    bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        hasSpawned = false;
        player = FindObjectOfType<PlayerMovementController>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !hasSpawned)
        {
            hasSpawned = true;
            GameObject e = Instantiate(enemy, spawnPoint.transform.position, Quaternion.Euler(0,0,0));
            e.SetActive(true);
        }
    }
}
