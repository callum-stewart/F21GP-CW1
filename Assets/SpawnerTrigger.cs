using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    [SerializeField]
    EnemyRepeatSpawner spawner;

    [SerializeField]
    bool isStartTrigger;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponentInParent<EnemyRepeatSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Debug.Log("Trigger hit: " + isStartTrigger);
            spawner.startSpawn = (isStartTrigger) ? true : false;
            Debug.Log("spawner is: " + spawner.startSpawn);
        }
    }
}
