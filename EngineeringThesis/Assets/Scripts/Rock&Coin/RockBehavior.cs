using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public Vector3 orginalPosition, targetPosition;
    public float moveSpeed = 3f;
    public bool canMoveLeft, canMoveRight, isMovingDown, test;
    public Transform rockMovePoint;
    public LayerMask rockLayer, playerLayer;
    public string[] layers = new string[] { "Dirt", "Rock", "Player", "Coin", "Border" };
    GameManager gm;

    void Start()
    {
        rockMovePoint.parent = null;
    }

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, rockMovePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, rockMovePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, 0f, 0f), .2f, LayerMask.GetMask(layers)))
                canMoveLeft = true;
            else
                canMoveLeft = false;

            if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, 0f, 0f), .2f, LayerMask.GetMask(layers)))
                canMoveRight = true;
            else
                canMoveRight = false;

            if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                test = true;

            if (Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, rockLayer))
            {
                if (canMoveLeft && canMoveRight)
                {
                    if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                    {
                        MoveLeft();
                    }
                    else if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                        MoveRight();
                }
                else
                {
                    if (canMoveLeft)
                    {
                        if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                        {
                            Debug.Log(Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(layers))); 
                            MoveLeft();
                        }
                    }
                    else if (canMoveRight)
                    {
                        if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                            MoveRight();
                    }
                }
            }

            else if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
            {
                MoveDown();
                /*isMovingDown = true;
                StartCoroutine("WaitToRockFall");*/
            }

            else if (Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, playerLayer) && isMovingDown)
                gm.gameOver = true;

            else
                isMovingDown = false;

        }
    }

    /*void LateUpdate()
    {
        if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
            isMovingDown = true;
        else
            isMovingDown = false;
    }*/

    public void MoveLeft()
    {
        rockMovePoint.position += new Vector3(-1f, 0f, 0f);
        //Debug.Log("Kamieñ w lewo");
    }

    public void MoveRight()
    {
        rockMovePoint.position += new Vector3(1f, 0f, 0f);
        //Debug.Log("Kamieñ w prawo");
    }

    public void MoveDown()
    {
        rockMovePoint.position += new Vector3(0f, -1f, 0f);
        isMovingDown = true;
        //Debug.Log("Kamieñ w dó³");
    }

    /*IEnumerator WaitToRockFall()
    {
        while (isMovingDown)
        {
            yield return new WaitForSeconds(.3f);
            MoveDown();
            Debug.Log("Czekaj");
            if (Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                isMovingDown = false;
        }
    }*/

    private void OnDrawGizmos()
    {
        /*Gizmos.color = Color.red;
        Gizmos.DrawSphere(rockMovePoint.position + new Vector3(-1f, -1f, 0f), .2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(rockMovePoint.position + new Vector3(1f, -1f, 0f), .2f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f);*/
        /*Gizmos.color = Color.red;
        Gizmos.DrawSphere(rockMovePoint.position, .2f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(rockMovePoint.position + new Vector3(1f, 0f, 0f), .2f);*/
    }
}
