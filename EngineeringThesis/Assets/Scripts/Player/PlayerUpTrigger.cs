using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpTrigger : MonoBehaviour
{
    PlayerMovment playerMovment;

    void Awake()
    {
        playerMovment = gameObject.GetComponentInParent<PlayerMovment>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
            playerMovment.canMoveUp = true;

        if (collision.CompareTag("Boundar"))
            playerMovment.canMoveUp = false;

        if (collision.CompareTag("Coin"))
            playerMovment.canMoveUp = true;
    }
}
