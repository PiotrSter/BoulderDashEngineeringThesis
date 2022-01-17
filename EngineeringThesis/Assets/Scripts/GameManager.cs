using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int howManyCoins;
    public bool gameOver, isLevelEnd;
    public float startX, startY, finishX, finishY;
    public GameObject levelEndPanel, gameOverPanel;
    public Text coinsText;
    void Awake()
    {
        howManyCoins = 0;
    }

    void Update()
    {
        coinsText.text = $"Coins to find: {howManyCoins}";

        if (howManyCoins == 0)
        {
            isLevelEnd = true;
            levelEndPanel.SetActive(true);
        }

        if (gameOver)
            gameOverPanel.SetActive(true);
    }
}
