using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCluster : MonoBehaviour
{
    public float speed = 4.0f;
    public AudioSource sound;
    public AudioSource gotHit;
    private float timeToPlay = 1.25f;
    private float timeSince = 0.0f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timeSince += Time.deltaTime;

        if (timeSince > timeToPlay)
        {
            sound.Play();
            timeSince = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Arrows"))
        {
            GameObject.Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.SubtractPlayerHealth();
            gotHit.Play();
            GameObject.Destroy(gameObject);
        }
    }
}
