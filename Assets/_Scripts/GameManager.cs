using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerHealth;
    public static int bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("player: " + playerHealth + " boss: " + bossHealth);
    }

    private void StartGame()
    {
        playerHealth = 5;
        bossHealth = 5;
    }

    public static void SubtractPlayerHealth()
    {
        playerHealth--;

        if (playerHealth == 0)
        {
            Debug.Log("Game OVer");
        }
    }

    public static void SubtractBossHealth()
    {
        bossHealth--;

        if (bossHealth == 0)
        {
            Debug.Log("Loading next level");
        }
    }
}
