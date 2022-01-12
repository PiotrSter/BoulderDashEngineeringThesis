using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public Vector3 orginalPosition, targetPosition;
    public float moveSpeed = 3f;
    public bool  isRockOrCoinDown, canMoveLeft, canMoveRight, isMovingDown, isMoving;
    public Transform rockMovePoint;
    public LayerMask rockLayer;
    public string[] canMoveSide = new string[] { "Rock", "Dirt", "Player", "Coin", "Border" }; //rock w getmask, nie mo¿e wykryæ layer "Rock" mo¿liwe ¿e to przez to ¿e jakby MoveLeft/Right ca³y czas sie wywo³ywa³o
    public string[] canMoveDown = new string[] { "Dirt", "Rock", "Player", "Coin", "Border" };

    void Start()
    {
        rockMovePoint.parent = null;
    }

    void Awake()
    {
        //isMovingDown = true;
        isRockOrCoinDown = false;
    }

    void Update() //ogarn¹æ te przemieszczanie, ¿eby nie sprawdza³ pozycji co klatke, tylko gdy ju¿ jest na pozycji to nie sprawdza, sprawdza dopiero w momencie gdy chcemy ¿eby kamieñ siê przesuwa³
    {
        transform.position = Vector3.MoveTowards(transform.position, rockMovePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, rockMovePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, 0f, 0f), .2f, LayerMask.GetMask(canMoveSide)))
                canMoveLeft = true;
            else
                canMoveLeft = false;

            if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, 0f, 0f), .2f, LayerMask.GetMask(canMoveSide)))
                canMoveRight = true;
            else
                canMoveRight = false;

            if (Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, rockLayer))
            {
                if (canMoveLeft && canMoveRight)
                {
                    if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(canMoveSide)))
                    {
                        Debug.Log("Lewa wolna");
                        MoveLeft();
                    }
                    else if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, -1f, 0f), .2f, LayerMask.GetMask(canMoveSide)))
                        MoveRight();
                }
                else
                {
                    if (canMoveLeft)
                    {
                        if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(canMoveSide)))
                        {
                            Debug.Log(Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(-1f, -1f, 0f), .2f, LayerMask.GetMask(canMoveSide))); //przy pchaniu kamienia, jeœli jest on na kamieniu, to po skosie wykrywa null
                            MoveLeft();
                        }
                    }
                    else if (canMoveRight)
                    {
                        if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(1f, -1f, 0f), .2f, LayerMask.GetMask(canMoveSide)))
                            MoveRight();
                    }
                }
            }

            else if (!Physics2D.OverlapCircle(rockMovePoint.position + new Vector3(0f, -1f, 0f), .2f, LayerMask.GetMask(canMoveDown)))
                MoveDown();

            else
                isMovingDown = false;

        }
    }

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
        Debug.Log("Czekaj");
        yield return new WaitForSeconds(2f);
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
