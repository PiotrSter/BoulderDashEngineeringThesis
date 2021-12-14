
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public float speed;
    public bool canMoveLeft, canMoveRight, canMoveUp, canMoveDown, canRockOrCoinDown;

    public Vector2 movement; 
    PlayerMovment playerMovment;

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
        /*if (canMoveLeft || canMoveRight)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }

        if (canMoveUp || canMoveDown)
        {
            movement.x = 0;
            movement.y = Input.GetAxisRaw("Vertical");
        }*/

        if (canMoveLeft && (canRockOrCoinDown || playerMovment.canMoveRockToLeft))
            rb.position = new Vector2(rb.position.x - 0.64f, rb.position.y);

        if (canMoveRight && (canRockOrCoinDown || playerMovment.canMoveRockToRight))
            rb.position = new Vector2(rb.position.x + 0.64f, rb.position.y);

        if (canMoveUp)
            rb.position = new Vector2(rb.position.x, rb.position.y + 0.64f);

        if (canMoveDown)
            rb.position = new Vector2(rb.position.x, rb.position.y - 0.64f);
    }

    /*void FixedUpdate()
    {
        if (canMoveLeft || canMoveRight || canMoveDown || canMoveUp)
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.collider.CompareTag("Rock"))
        {
            canMoveLeft = false;
            canMoveRight = false;
            canMoveUp = false;
            canMoveDown = false;
            //Debug.Log("Ska�y");
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}