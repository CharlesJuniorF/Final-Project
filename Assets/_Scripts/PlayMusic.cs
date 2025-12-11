using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource music;
    public float timeToPlay = 1.25f;
    public float timeSince = 0.0f;

    void Update()
    {
        timeSince += Time.deltaTime;

        if (timeSince > timeToPlay)
        {
            music.Play();
            timeSince = 0f;
        }
    }
}
