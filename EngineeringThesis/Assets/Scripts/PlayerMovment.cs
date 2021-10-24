using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D rb;
    public bool canLeftRightMove, canUpDownMove;

    public Vector2 movement;
    public Animator animator;
    
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
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
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
