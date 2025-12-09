using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject QuitMenu;

    public static int playerHealth = 5;
    public static int bossHealth = 5;

    public static bool _paused;
    public static bool _gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        QuitMenu.SetActive(false);
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("player: " + playerHealth + " boss: " + bossHealth);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                _paused = true;
            }
            else
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                _paused = false;
            }
        }
    }

    private void StartGame()
    {
        playerHealth = 5;
        bossHealth = 5;
        _paused = false;
        _gameOver = false;
    }

    public static void SubtractPlayerHealth()
    {
        playerHealth--;

        if (playerHealth == 0)
        {
            Debug.Log("Game Over");
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
