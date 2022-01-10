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
        {
            playerMovment.canMoveUp = true;
            //Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Boundar"))
        {
            playerMovment.canMoveUp = false;
            //Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Coin"))
        {
            playerMovment.canMoveUp = true;
            //Debug.Log($"{this.name} {collision.name}");
        }

        if (collision.CompareTag("Rock"))
        {
            playerMovment.canMoveUp = false;
            //Debug.Log($"{this.name} {collision.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundar"))
            playerMovment.canMoveUp = true;

        if (collision.CompareTag("Rock"))
            playerMovment.canMoveUp = true;
    }
}
