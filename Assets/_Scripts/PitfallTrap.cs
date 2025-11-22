using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallTrap : MonoBehaviour
{
    public Rigidbody playerBody;
    public float forceUp;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerBody.AddForce(1.0f, forceUp, 1.0f, ForceMode.Impulse);

            //add a health decrement here
        }
    }

}
