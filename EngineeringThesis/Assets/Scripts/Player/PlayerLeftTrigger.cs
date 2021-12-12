using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftTrigger : MonoBehaviour
{
    PlayerMovment playerMovment;

    void Awake()
    {
        playerMovment = gameObject.GetComponentInParent<PlayerMovment>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
            playerMovment.canMoveLeft = true;

        if (collision.CompareTag("Boundar"))
            playerMovment.canMoveLeft = false;

        if (collision.CompareTag("Coin"))
            playerMovment.canMoveLeft = true;

    }
}
