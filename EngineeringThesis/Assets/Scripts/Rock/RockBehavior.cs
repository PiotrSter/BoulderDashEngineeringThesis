
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public float speed;
    public bool canMoveLeft, canMoveRight, canMoveUp, canMoveDown;

    public Vector2 movement; 
    PlayerMovment playerMovment;

    Rigidbody2D rb;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        speed = 1f;
        canMoveLeft = false;
        canMoveRight = false;
        canMoveUp = false;
        canMoveDown = false;
        playerMovment = GameObject.Find("Player").GetComponent<PlayerMovment>();
    }

    void Update()
    {
        if (canMoveLeft || canMoveRight)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }

        if (canMoveUp || canMoveDown)
        {
            movement.x = 0;
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        if (canMoveLeft || canMoveRight || canMoveDown || canMoveUp)
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Rock"))
        {
            canMoveLeft = false;
            canMoveRight = false;
            canMoveUp = false;
            canMoveDown = false;
            Debug.Log("Ska³y");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
