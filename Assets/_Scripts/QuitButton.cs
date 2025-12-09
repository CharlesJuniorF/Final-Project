using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public GameObject QuitPanel;

    public void onClick()
    {
        GameManager._youSure = true;
    }
}
