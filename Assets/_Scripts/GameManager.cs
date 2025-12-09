using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject QuitMenu;
    public GameObject GameOverMenu;

    public static int playerHealth = 5;
    public static int bossHealth = 5;

    public static bool _paused;
    public static bool _youSure;
    public static bool _gameOver;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        QuitMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("player: " + playerHealth + " boss: " + bossHealth);

        if (Input.GetKeyDown(KeyCode.Escape) && !_gameOver)
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

        if (_youSure && _paused)
        {
            PauseMenu.SetActive(false);
            QuitMenu.SetActive(true);
        }

        if (playerHealth <= 0)
        {
            Time.timeScale = 0;
            _gameOver = true;
            GameOverMenu.SetActive(true);
        }
    }

    private void StartGame()
    {
        playerHealth = 1;
        bossHealth = 5;
        _paused = false;
        _gameOver = false;
    }

    public static void SubtractPlayerHealth()
    {
        playerHealth--;
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
