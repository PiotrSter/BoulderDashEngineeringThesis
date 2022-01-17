using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : RockAndCoinClass
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            isMovingDown = false;
            gm.gameOver = false; 
            objectMovePoint.position += new Vector3(0f, 1f, 0f);            
        }
    }
}
