
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public float speed;
    public bool canMoveLeftRight, canMoveUpDown;

    public Vector2 movement; 
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
        if (playerMovment.canLeftRightMove && canMoveLeftRight)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }

        if (playerMovment.canUpDownMove && canMoveUpDown)
        {
            movement.x = 0;
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
    }

    void FixedUpdate()
    {
        if (canMoveLeftRight || canMoveUpDown)
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Rock"))
        {
            canMoveLeftRight = false;
            canMoveUpDown = false;
            Debug.Log("Ska³y");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
