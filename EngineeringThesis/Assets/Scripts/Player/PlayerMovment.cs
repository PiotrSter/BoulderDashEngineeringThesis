using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D rb; /*rockRbLeft, rockRbRight;*/
    public RockBehavior rockLeft, rockRight;
    public bool canMoveLeft, canMoveRight, canMoveUp, canMoveDown, isRockOnLeft, isRockOnRight, canMoveRockToLeft, canMoveRockToRight;
    public Animator animator;
    
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        canMoveLeft = true;
        canMoveRight = true;
        canMoveDown = true;
        canMoveUp = true;
        canMoveRockToLeft = false;
        canMoveRockToRight = false;
        isRockOnLeft = false;
        isRockOnRight = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canMoveRockToLeft)
            {
                rockLeft.MoveLeft();
                rb.position = new Vector2(rb.position.x - 0.64f, rb.position.y);
            }

            if (canMoveLeft)
                rb.position = new Vector2(rb.position.x - 0.64f, rb.position.y);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (canMoveRockToRight)
            {
                rockRight.MoveRight();
                rb.position = new Vector2(rb.position.x + 0.64f, rb.position.y);
            }

            if (canMoveRight)
                rb.position = new Vector2(rb.position.x + 0.64f, rb.position.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && canMoveUp)
            rb.position = new Vector2(rb.position.x, rb.position.y + 0.64f);

        if (Input.GetKeyDown(KeyCode.S) && canMoveDown)
            rb.position = new Vector2(rb.position.x, rb.position.y - 0.64f);



        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }
}
