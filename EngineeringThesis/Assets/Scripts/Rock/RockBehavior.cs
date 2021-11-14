
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public float speed;
    public bool canMoveLeftRight, canMoveUpDown;

    Vector2 movement; 
    PlayerMovment playerMovment;

    Rigidbody2D rb;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        speed = 1f;
        canMoveLeftRight = false;
        canMoveUpDown = false;
        playerMovment = GameObject.Find("Player").GetComponent<PlayerMovment>();
    }

    void Update()
    {
        if (playerMovment.canLeftRightMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }

        if (playerMovment.canUpDownMove)
        {
            movement.x = 0;
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        if (canMoveLeftRight || canMoveUpDown)
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
