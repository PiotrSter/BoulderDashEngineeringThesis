using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrigger : MonoBehaviour
{
    RockBehavior rockBehavior;
    Rigidbody2D rb;
    void Start()
    {
        rockBehavior = gameObject.GetComponentInParent<RockBehavior>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
        {
            rockBehavior.canMoveLeft = false;
            rockBehavior.playerMovment.canMoveRockToLeft = false;       
        }

        if (collision.CompareTag("Rock"))
        {
            rockBehavior.canMoveLeft = false;
            rockBehavior.playerMovment.canMoveRockToLeft = false;
        }

        if (collision.CompareTag("Coin"))
        {
            rockBehavior.canMoveLeft = false;
            rockBehavior.playerMovment.canMoveRockToLeft = false;
        }

        if (collision.CompareTag("Boundar"))
        {
            rockBehavior.canMoveLeft = false;
            rockBehavior.playerMovment.canMoveRockToLeft = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
            rockBehavior.canMoveLeft = true;

        if (collision.CompareTag("Rock"))
            rockBehavior.canMoveLeft = true;

        if (collision.CompareTag("Coin"))
            rockBehavior.canMoveLeft = true;

        if (collision.CompareTag("Boundar"))
            rockBehavior.canMoveLeft = true;
    }
}
