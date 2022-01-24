using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public float tempTimeScale;
    GameManager gm;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gm.gameOver && !gm.isLevelEnd)
        {
            if (Time.timeScale != 0)
                tempTimeScale = Time.timeScale;

            PauseGame();
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(!pausePanel.activeInHierarchy);

        if (Time.timeScale != 0)
            Time.timeScale = 0;
        else
            Time.timeScale = tempTimeScale;
    }

    public void ReasumeButton()
    {
        PauseGame();
    }

    public void ResetButton()
    {
        PauseGame();
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
