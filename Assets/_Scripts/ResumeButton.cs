using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject PauseMenu;
    public void OnClick()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameManager._paused = false;
    }
}
