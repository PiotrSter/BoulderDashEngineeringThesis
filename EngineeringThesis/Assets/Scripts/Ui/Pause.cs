using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public float tempTimeScale;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void ExitButton()
    {
        Application.Quit();
    }
}
