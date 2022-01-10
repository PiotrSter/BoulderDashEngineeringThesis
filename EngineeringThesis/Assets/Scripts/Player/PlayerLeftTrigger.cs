using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftTrigger : MonoBehaviour
{
    PlayerMovment playerMovment;
    RockBehavior rockBehavior;

    void Awake()
    {
        playerMovment = gameObject.GetComponentInParent<PlayerMovment>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
        {
            playerMovment.canMoveLeft = true;
           // Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Boundar"))
        {
            playerMovment.canMoveLeft = false;
            //Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Coin"))
        {
            playerMovment.canMoveLeft = true;
            //Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Rock"))
        {
            playerMovment.rockLeft = collision.GetComponent<RockBehavior>();
            rockBehavior = collision.GetComponent<RockBehavior>();
            /*if (rockBehavior.canMoveLeft)
                playerMovment.canMoveRockToLeft = true;*/
            playerMovment.canMoveLeft = false;
            //Debug.Log($"{this.name} {collision.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundar"))
            playerMovment.canMoveLeft = true;

        if (collision.CompareTag("Rock"))
        {
            playerMovment.canMoveLeft = true;
            playerMovment.canMoveRockToLeft = false;
            playerMovment.isRockOnLeft = false;
        }
    }
}
