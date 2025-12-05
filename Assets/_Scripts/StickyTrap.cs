using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTrap : MonoBehaviour
{
    public Player player;
    public float slowDown = 3f;
    public float speedUp = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.MoveSpeed -= slowDown;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.MoveSpeed += speedUp;
        }
    }
}
