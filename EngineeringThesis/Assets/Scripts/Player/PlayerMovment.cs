using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public bool isMoving;
    public Vector3 orginalPosition, targetPosition;
    public float timeToMove = 0.2f, moveSpeed = 3f;
    public Transform movePoint;
    public Rigidbody2D rb; 
    public RockBehavior rockLeft, rockRight;
    public bool canMoveLeft, canMoveRight, canMoveUp, canMoveDown, isRockOnLeft, isRockOnRight, canMoveRockToLeft, canMoveRockToRight;
    public Animator animator;
    public LayerMask whatStopedMovment, rockLayer;

    void Start()
    {
        movePoint.parent = null;
    }

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
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

       /* if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, rockLayer))
        {
            if (Input.GetAxisRaw("Horizontal") == -1)
                isRockOnLeft = true;
            else if (Input.GetAxisRaw("Horizontal") == 1)
                isRockOnRight = true;
        }*/

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopedMovment))
                {
                    /*if (rockLeft.canMoveLeft)
                        rockLeft.MoveLeft();

                    if (canMoveRockToRight)
                        rockRight.MoveRight();*/

                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopedMovment))
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }

        }

        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal")); //animator nie dzia³a :(
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f);
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f);
    }


    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving && canMoveUp)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            if (canMoveRockToLeft)
            {
                StartCoroutine(rockLeft.MoveRock(Vector3.left));
                StartCoroutine(MovePlayer(Vector3.left));
            }

            if (canMoveLeft)
                StartCoroutine(MovePlayer(Vector3.left));
        }

        if (Input.GetKeyDown(KeyCode.S) && !isMoving && canMoveDown)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            if (canMoveRockToRight)
            {
                StartCoroutine(rockRight.MoveRock(Vector3.right));
                StartCoroutine(MovePlayer(Vector3.right));
            }    

            if (canMoveRight)
                StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        orginalPosition = transform.position;

        targetPosition = orginalPosition + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(orginalPosition, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
    }*/


    /*public float playerSpeed;
    public Rigidbody2D rb; *//*rockRbLeft, rockRbRight;*//*
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



        *//*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);*//*
    }*/
}
