using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D rb;
    public bool canLeftRightMove, canUpDownMove, canMoveLeft, canMoveRight, canMoveUp, canMoveDown;

    public Vector2 movement;
    public Animator animator;
    
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        canMoveLeft = false;
        canMoveRight = false;
        canMoveDown = false;
        canMoveUp = false;
    }

    void Update()
    {
        /*if (Input.GetAxisRaw("Horizontal") != 0)
        {
            canLeftRightMove = true;
            canUpDownMove = false;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            canLeftRightMove = false;
            canUpDownMove = true;
        }

        if (canLeftRightMove && !canUpDownMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }
        if (!canLeftRightMove && canUpDownMove)
        {
            movement.x = 0;
            movement.y = Input.GetAxisRaw("Vertical");
        }*/

        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft)
            rb.position = new Vector2(rb.position.x - 0.64f, rb.position.y);

        if (Input.GetKeyDown(KeyCode.D) && canMoveRight)
            rb.position = new Vector2(rb.position.x + 0.64f, rb.position.y);

        if (Input.GetKeyDown(KeyCode.W) && canMoveUp)
            rb.position = new Vector2(rb.position.x, rb.position.y + 0.64f);

        if (Input.GetKeyDown(KeyCode.S) && canMoveDown)
            rb.position = new Vector2(rb.position.x, rb.position.y - 0.64f);

        //Sterowanie jako przeksakiwanie o "ca³¹ kratkê"



        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }

    /*private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }*/
}
