using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDownTrigger : MonoBehaviour
{
    PlayerMovment playerMovment;

    void Awake()
    {
        playerMovment = gameObject.GetComponentInParent<PlayerMovment>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
        {
            playerMovment.canMoveDown = true;
            Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Boundar"))
        {
            playerMovment.canMoveDown = false;
            Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Coin"))
        {
            playerMovment.canMoveDown = true;
            Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Rock"))
        {
            playerMovment.canMoveDown = false;
            Debug.Log($"{this.name} {collision.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundar"))
            playerMovment.canMoveDown = true;

        if (collision.CompareTag("Rock"))
            playerMovment.canMoveDown = true;
    }
}
