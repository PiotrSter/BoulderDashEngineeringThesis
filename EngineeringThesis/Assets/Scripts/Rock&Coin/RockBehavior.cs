
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public float speed;
    public bool canMoveLeft, canMoveRight, canMoveUp, canMoveDown, canRockOrCoinDown;

    public Vector2 movement; 
    public PlayerMovment playerMovment;

    Rigidbody2D rb;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        playerMovment = GameObject.Find("Player").GetComponent<PlayerMovment>();
        speed = 1f;
        canMoveLeft = true;
        canMoveRight = true;
        canMoveUp = false;
        canMoveDown = true;
        canRockOrCoinDown = false;
    }

    void Update()
    {

        if (canMoveLeft && canRockOrCoinDown)
            rb.position = new Vector2(rb.position.x - 0.64f, rb.position.y);

        if (canMoveRight && canRockOrCoinDown)
            rb.position = new Vector2(rb.position.x + 0.64f, rb.position.y);

        /*if (canMoveUp)
            rb.position = new Vector2(rb.position.x, rb.position.y + 0.64f);*/

        if (canMoveDown)
            rb.position = new Vector2(rb.position.x, rb.position.y - 0.64f);
    }
}
