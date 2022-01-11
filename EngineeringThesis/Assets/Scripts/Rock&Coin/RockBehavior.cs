using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public Vector3 orginalPosition, targetPosition;
    public float timeToMove = 0.2f, moveSpeed = 3f;
    public bool  isRockOrCoinDown, canMoveLeft, canMoveRight;
    public Transform rockMovePoint;
    public LayerMask coinOrRockLayer, dirtLayer, borderLayer, playerLayer;
    public string[] canMoveSide = new string[] { "RockOrCoin", "Dirt", "Border", "Player" };
    public string[] canMoveDown = new string[] { "Dirt", "Border" };

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
        isRockOrCoinDown = false;
    }

    void Update() // dorobiæ to ¿e jesli po ukosie coœ stoi to siê nie œlizga, i jeœli pod nim jest kamieñ, ale z dwóch stron blokuje to nie spada
    {
        transform.position = Vector3.MoveTowards(transform.position, rockMovePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, rockMovePoint.position) == 0)
        {

            if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, 0f, 0f), .2f, LayerMask.GetMask(canMoveSide)))
                canMoveLeft = true;
            else
                canMoveLeft = false;

            if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, 0f, 0f), .2f, LayerMask.GetMask(canMoveSide)))
                canMoveRight = true;
            else
                canMoveRight = false;

            if (Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, coinOrRockLayer))
            {
                if (canMoveLeft)
                {
                    Debug.Log(Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, 0f, 0f), .2f, LayerMask.GetMask(canMoveSide)));
                    MoveLeft();
                }
                if (canMoveRight)
                {
                    Debug.Log(Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, 0f, 0f), .2f, LayerMask.GetMask(canMoveSide)));
                    MoveRight();
                }
            }

            if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(canMoveDown)))
                MoveDown();
        }

    }

    public void MoveLeft()
    {
        rockMovePoint.position += new Vector3(-1f, 0f, 0f);
        Debug.Log("Kamieñ w lewo");
    }

    public void MoveRight()
    {
        rockMovePoint.position += new Vector3(1f, 0f, 0f);
        Debug.Log("Kamieñ w prawo");
    }

    public void MoveDown()
    {
        rockMovePoint.position += new Vector3(0f, -1f, 0f);
        Debug.Log("Kamieñ w dó³");
    }

    private void OnDrawGizmos()
    {
        /*Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position + new Vector3(0f, -1f, 0f), .2f);*/
        /*Gizmos.color = Color.red;
        Gizmos.DrawSphere(rockMovePoint.position, .2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(rockMovePoint.position + new Vector3(-1f, 0f, 0f), .2f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(rockMovePoint.position + new Vector3(1f, 0f, 0f), .2f);*/
    }
}
