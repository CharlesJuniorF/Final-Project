using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTrap : MonoBehaviour
{
    public Player player;
    public float sleedUp = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.MoveSpeed -= sleedUp;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.MoveSpeed += sleedUp;
        }
    }
}
