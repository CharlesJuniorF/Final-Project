using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    public GameObject[] livesCount;

    // Update is called once per frame
    void Update()
    {
        //hide all tokens
        for (int i = 0; i < livesCount.Length; i++)
        {
            livesCount[i].SetActive(false);
        }

        //reveal all that are active
        for (int i = 0; i < GameManager.bossHealth; i++)
        {
            livesCount[i].SetActive(true);
        }
    }
}