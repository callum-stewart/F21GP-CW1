using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRepeatSpawner : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    float respawnRate = 10f;
    float spawnTimer;

    public bool startSpawn { get; set; }

    void Start()
    {
        startSpawn = false;
        spawnTimer = respawnRate;
    }

    private void Update()
    {
        if (startSpawn)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                GameObject e = Instantiate(enemy, spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
                e.SetActive(true);
                spawnTimer = respawnRate;
            }
        }
    }
}
