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
        {
            playerMovment.canMoveRight = true;
            Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Boundar"))
        {
            playerMovment.canMoveRight = false;
            Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Coin"))
        {
            playerMovment.canMoveRight = true;
            Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Rock"))
        {
            playerMovment.isRockOnRight = true;
            Debug.Log($"{this.name} {collision.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundar"))
            playerMovment.canMoveRight = true;

        if (collision.CompareTag("Rock"))
        {
            playerMovment.isRockOnRight = false;
            playerMovment.canMoveRockToRight = false;
        }
    }
}
