using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public Vector3 orginalPosition, targetPosition;
    public float timeToMove = 0.2f, moveSpeed = 3f;
    public bool /*isMoving, canMoveLeft, canMoveRight, canMoveUp, canMoveDown,*/ canRockOrCoinDown;
    public Transform rockMovePoint;
    public LayerMask coinOrRockLayer, dirtLayer, borderLayer, playerLayer;

    public Vector2 movement; 
    public PlayerMovment playerMovment;

    Rigidbody2D rb;

    void Start()
    {
        rockMovePoint.parent = null;
    }

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        playerMovment = GameObject.Find("Player").GetComponent<PlayerMovment>();
        /*canMoveLeft = true;
        canMoveRight = true;
        canMoveUp = false;
        canMoveDown = true;*/
        canRockOrCoinDown = false;
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), .2f, coinOrRockLayer))
        {
            if (/*!Physics2D.OverlapCircle(rockMovePoint.position, .2f, coinOrRockLayer) ||*/ !Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, 0f, 0f), .2f, dirtLayer))
            {
                MoveLeft();
            }
            if (/*!Physics2D.OverlapCircle(rockMovePoint.position, .2f, coinOrRockLayer) ||*/ !Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, 0f, 0f), .2f, dirtLayer))
                MoveRight();
        }

        if (!Physics2D.OverlapCircle(rockMovePoint.position, .2f, dirtLayer) /*|| !Physics2D.OverlapCircle(rockMovePoint.position, .2f, borderLayer)*/)
            MoveDown();

    }

    public void MoveLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, rockMovePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, rockMovePoint.position) <= .05f && transform.position.x % 1 == 0)
        {
            rockMovePoint.position += new Vector3(-1f, 0f, 0f);
            Debug.Log("Kamieñ w lewo");
        }
    }

    public void MoveRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, rockMovePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, rockMovePoint.position) <= .05f && transform.position.x % 1 == 0)
        {
                rockMovePoint.position += new Vector3(1f, 0f, 0f);
        }
    }

    void MoveDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, rockMovePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, rockMovePoint.position) <= .05f && transform.position.y % 1 == 0)
        {
            rockMovePoint.position += new Vector3(0f, -1f, 0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position + new Vector3(0f, -1f, 0f), .2f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rockMovePoint.position, .2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(rockMovePoint.position + new Vector3(-1f, 0f, 0f), .2f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(rockMovePoint.position + new Vector3(1f, 0f, 0f), .2f);
    }

    /*void Update()
    {

        if (canMoveLeft && canRockOrCoinDown)
            StartCoroutine(MoveRock(Vector3.left));

        if (canMoveRight && canRockOrCoinDown)
            StartCoroutine(MoveRock(Vector3.right));

        if (canMoveDown)
            StartCoroutine(MoveRock(Vector3.down));
    }*/

    /*public IEnumerator MoveRock (Vector3 direction)
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

    /*public void MoveLeft()
    {
        rb.position = new Vector2(rb.position.x - 0.64f, rb.position.y);
    }

    public void MoveRight()
    {
        rb.position = new Vector2(rb.position.x + 0.64f, rb.position.y);
    }

    public void MoveDown()
    {
        rb.position = new Vector2(rb.position.x, rb.position.y - 0.64f);
    }

    private IEnumerator WaitToFallDown()
    {
        while (canMoveDown)
        {
            MoveDown();
            yield return new WaitForSeconds(0.3f);
        }
    }*/
}
