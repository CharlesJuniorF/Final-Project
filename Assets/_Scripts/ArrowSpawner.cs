using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrows;
    public Transform spawnPosition;
    public float timeToSpawn = 3.0f;
    public float timeSince = 0.0f;

    private void Update()
    {
        timeSince += Time.deltaTime;

        if(timeSince > timeToSpawn)
        {
            Instantiate(arrows, spawnPosition.position, spawnPosition.rotation);
            timeSince = 0f;
        }
    }
}
