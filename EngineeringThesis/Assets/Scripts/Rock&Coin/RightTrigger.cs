using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrigger : MonoBehaviour
{
    RockBehavior rockBehavior;
    Rigidbody2D rb;
    void Start()
    {
        rockBehavior = gameObject.GetComponentInParent<RockBehavior>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
        {
            rockBehavior.canMoveRight = false;
            rockBehavior.playerMovment.canMoveRockToRight = false;
        }

        if (collision.CompareTag("Rock"))
        {
            rockBehavior.canMoveRight = false;
            rockBehavior.playerMovment.canMoveRockToRight = false;
        }

        if (collision.CompareTag("Coin"))
        {
            rockBehavior.canMoveRight = false;
            rockBehavior.playerMovment.canMoveRockToRight = false;
        }

        if (collision.CompareTag("Boundar"))
        {
            rockBehavior.canMoveRight = false;
            rockBehavior.playerMovment.canMoveRockToRight = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
            rockBehavior.canMoveRight = true;

        if (collision.CompareTag("Rock"))
            rockBehavior.canMoveRight = true;

        if (collision.CompareTag("Coin"))
            rockBehavior.canMoveRight = true;

        if (collision.CompareTag("Boundar"))
            rockBehavior.canMoveRight = true;
    }*/
}
