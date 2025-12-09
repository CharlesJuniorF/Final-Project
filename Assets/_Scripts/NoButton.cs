using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButton : MonoBehaviour
{
    public GameObject QuitMenu;
    public GameObject PauseMenu;

    public void OnClick()
    {
        GameManager._youSure = false;
        GameManager._paused = true;
        QuitMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }
}
