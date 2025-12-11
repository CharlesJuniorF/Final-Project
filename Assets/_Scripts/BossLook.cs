using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLook : MonoBehaviour
{
    public GameObject bossProjectile;
    public Transform spawnPosition;
    public GameObject player;
    public float timeToSpawn = 3.0f;
    public float timeSince = 0.0f;
    public AudioSource sound;

    private void Update()
    {
        Vector3 playerPos = player.transform.position - transform.position;

        Quaternion targetDirect = Quaternion.LookRotation(playerPos);

        timeSince += Time.deltaTime;

        if (timeSince > timeToSpawn)
        {
            Instantiate(bossProjectile, spawnPosition.position, targetDirect);
            sound.Play();
            timeSince = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.bossHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}
