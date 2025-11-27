using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowCluster : MonoBehaviour
{
    public float speed = 4.0f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            GameObject.Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
