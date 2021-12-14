using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTrigger : MonoBehaviour
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
            rockBehavior.canMoveUp = false;

        if (collision.CompareTag("Rock"))
            rockBehavior.canMoveUp = false;

        if (collision.CompareTag("Coin"))
            rockBehavior.canMoveUp = false;

        if (collision.CompareTag("Boundar"))
            rockBehavior.canMoveUp = false;
    }

}
