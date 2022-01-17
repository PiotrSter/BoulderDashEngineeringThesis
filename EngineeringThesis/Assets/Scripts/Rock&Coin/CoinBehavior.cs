using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : RockAndCoinClass
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            gm.howManyCoins--;
            this.objectMovePoint.parent = this.transform;
            Destroy(this.gameObject);
        }
    }
}
