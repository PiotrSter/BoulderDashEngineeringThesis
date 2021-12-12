using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRightTrigger : MonoBehaviour
{
    PlayerMovment playerMovment;

    void Awake()
    {
        playerMovment = gameObject.GetComponentInParent<PlayerMovment>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
            playerMovment.canMoveRight = true;

        if (collision.CompareTag("Boundar"))
            playerMovment.canMoveRight = false;

        if (collision.CompareTag("Coin"))
            playerMovment.canMoveRight = true;
    }
}
