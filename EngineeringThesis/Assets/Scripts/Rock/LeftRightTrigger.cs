using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightTrigger : MonoBehaviour
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
        if (collision.name == "Player")
        {
            rockBehavior.canMoveLeftRight = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            rockBehavior.canMoveLeftRight = false;
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
