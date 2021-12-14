using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D rb;
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
        isRockOnLeft = false;
        isRockOnRight = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft)
        {
            rb.position = new Vector2(rb.position.x - 0.64f, rb.position.y);

            if (isRockOnLeft)
                canMoveRockToLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.D) && canMoveRight)
        {
            rb.position = new Vector2(rb.position.x + 0.64f, rb.position.y);

            if (isRockOnRight)
                canMoveRockToRight = true;
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
