using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int howManyCoin;
    public bool gameOver, isLevelEnd;
    public float startX, startY, finishX, finishY;
    void Awake()
    {
        howManyCoin = 0;
    }

    void Update()
    {
        if (howManyCoin == 0)
            isLevelEnd = true;
    }
}
