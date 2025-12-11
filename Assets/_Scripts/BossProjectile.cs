using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 4.0f;
    public AudioSource projectileSound;
    public AudioSource gotHit;
    public float timeToSpawn = 3.0f;
    public float timeSince = 0.0f;

    private void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        timeSince += Time.deltaTime;

        if (timeSince > timeToSpawn)
        {
            projectileSound.Play();
            timeSince = 0f;
        }
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.SubtractPlayerHealth();
            gotHit.Play();
            Destroy(gameObject);
        }
    }
}
