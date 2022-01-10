using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTrigger : MonoBehaviour
{
    RockBehavior rockBehavior;
    Rigidbody2D rb;
    void Start()
    {
        rockBehavior = gameObject.GetComponentInParent<RockBehavior>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
            rockBehavior.canMoveDown = false;

        if (collision.CompareTag("Rock"))
        {
            rockBehavior.canMoveDown = false;
            rockBehavior.canRockOrCoinDown = true;
        }

        if (collision.CompareTag("Coin"))
        {
            rockBehavior.canMoveDown = false;
            rockBehavior.canRockOrCoinDown = true;
        }

        if (collision.CompareTag("Boundar"))
            rockBehavior.canMoveDown = false;

        *//*if (collision.CompareTag("EmptySpace"))
            rockBehavior.canMoveDown = true;*/

        /*if (!collision)
        {
            //Debug.Log("Nic");
            rockBehavior.canMoveDown = true;
        }*//*
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
            rockBehavior.canMoveDown = true;

        if (collision.CompareTag("Rock"))
        {
            rockBehavior.canMoveDown = true;
            rockBehavior.canRockOrCoinDown = false;
        }

        if (collision.CompareTag("Coin"))
        {
            rockBehavior.canMoveDown = true;
            rockBehavior.canRockOrCoinDown = false;
        }

        if (collision.CompareTag("Boundar"))
            rockBehavior.canMoveDown = true;*/

        /*if (collision)
            rockBehavior.canMoveDown = true;
    } */


    /* Nie dzia³a, bo wychodzi z dirta i zaczyna spadaæ zanim wy³apie ¿e jest pod nim kolejny dirt.
       Pomys³y na rozwi¹zanie:
       1. OpuŸniæ spadanie, podobnie jak Maciej robi³ z tym czekaniem
       2. Spróbowac jakoœ wykrywaæ wejœcie w "brak obiektu"
     */
}
