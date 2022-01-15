using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAndCoinClass : MonoBehaviour
{
    public Vector3 orginalPosition, targetPosition;
    public float moveSpeed = 3f;
    public bool canMoveLeft, canMoveRight, isMovingDown, isDirt;
    public Transform objectMovePoint;
    public LayerMask rockLayer, playerLayer, coinLayer;
    public string[] rockAndCoinLayers = new string[] { "Rock", "Coin" };
    public string[] layers = new string[] { "Dirt", "Rock", "Player", "Coin", "Border" };
    public GameManager gm;
    public GameObject dirt;
    public RockAndCoinClass objectVertical;
    public Rigidbody2D rb;

    void Start()
    {
        objectMovePoint.parent = null;
    }

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectMovePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, objectMovePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(-1f, 0f, 0f), .2f, LayerMask.GetMask(layers)))
                canMoveLeft = true;
            else
                canMoveLeft = false;

            if (!Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(1f, 0f, 0f), .2f, LayerMask.GetMask(layers)))
                canMoveRight = true;
            else
                canMoveRight = false;

            if (Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(rockAndCoinLayers)))
            {
                if (objectVertical == null)
                    objectVertical = Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(rockAndCoinLayers)).GetComponent<RockAndCoinClass>();

                if (canMoveLeft && canMoveRight && !objectVertical.isMovingDown)
                {
                    if (!Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                    {
                        Debug.Log(Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(0f, -1f, 0f), .2f, rockLayer));
                        MoveLeft();
                    }
                    else if (!Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(1f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                    {
                        Debug.Log(Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(1f, -1f, 0f), .2f, LayerMask.GetMask(layers)));
                        MoveRight();
                    }
                }
                else
                {
                    if (canMoveLeft && !objectVertical.isMovingDown)
                    {
                        if (!Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                        {
                            Debug.Log(Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(layers)));
                            MoveLeft();
                        }
                    }
                    else if (canMoveRight && !objectVertical.isMovingDown)
                    {
                        if (!Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(1f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
                            MoveRight();
                    }
                }
            }

            else if (!Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(layers)))
            {
                MoveDown();
                /*if (!isDirt)
                    MoveDown();
                else
                    isDirt = false;*/
                /*isMovingDown = true;
                StartCoroutine("WaitToRockFall");*/
            }

            else if (Physics2D.OverlapCircle(objectMovePoint.position + new Vector3(0f, -1f, 0f), .2f, playerLayer) && isMovingDown)
                gm.gameOver = true;

            else
            {
                isMovingDown = false;
                objectVertical = null;
            }

        }
    }

    public void MoveLeft()
    {
        objectMovePoint.position += new Vector3(-1f, 0f, 0f);
        //Debug.Log("Kamieñ w lewo");
    }

    public void MoveRight()
    {
        objectMovePoint.position += new Vector3(1f, 0f, 0f);
        //Debug.Log("Kamieñ w prawo");
    }

    public void MoveDown()
    {
        objectMovePoint.position += new Vector3(0f, -1f, 0f);
        isMovingDown = true;
        //Debug.Log("Kamieñ w dó³");
    }

    /*private void OnDrawGizmos()
    {
        *//* Gizmos.color = Color.red;
         Gizmos.DrawSphere(objectMovePoint.position + new Vector3(-1f, -1f, 0f), .2f);
         Gizmos.color = Color.blue;
         Gizmos.DrawSphere(objectMovePoint.position + new Vector3(1f, -1f, 0f), .2f);*/
        /*Gizmos.color = Color.green;
        Gizmos.DrawSphere(objectMovePoint.position + new Vector3(0f, -1f, 0f), .2f);*/
        /*Gizmos.color = Color.red;
        Gizmos.DrawSphere(objectMovePoint.position, .2f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(objectMovePoint.position + new Vector3(1f, 0f, 0f), .2f);*//*
    }*/
}
