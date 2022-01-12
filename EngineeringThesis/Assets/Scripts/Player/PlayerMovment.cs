using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public bool isMoving;
    public Vector3 orginalPosition, targetPosition;
    public float moveSpeed = 3f;
    public Transform movePoint;
    public RockBehavior rockHorizontal;
    public Animator animator;
    public LayerMask whatStopedMovment, rockLayer;

    void Start()
    {
        movePoint.parent = null;
    }

    void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopedMovment) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, rockLayer))
                {                 
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

                else if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, rockLayer)) 
                {
                    rockHorizontal = Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, rockLayer).GetComponent<RockBehavior>(); //tutaj nie wiem czy nie trzeba tego przerobi�, �eby GetComponent nie by�o w update
                    if (Input.GetAxisRaw("Horizontal") == -1 && rockHorizontal.canMoveLeft)
                    {
                        rockHorizontal.MoveLeft();
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                    else if (Input.GetAxisRaw("Horizontal") == 1 && rockHorizontal.canMoveRight)
                    {
                        rockHorizontal.MoveRight();
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopedMovment))
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }

        }

        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal")); //animator nie dzia�a :(
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f);
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f);
    }
}
