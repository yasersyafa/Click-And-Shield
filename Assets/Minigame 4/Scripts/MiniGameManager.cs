using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if(!isPaused) {
            Timer.instance.currentTimer -= Time.deltaTime;
            if(Timer.instance.currentTimer <= 0) {
                GameOver();
            }
        }
    }

    public void WinGame()
    {
        GameManager.instance.WinMinigame();
        GameManager.instance.GoToRewardScene();
    }

    public void GameOver()
    {
        GameManager.instance.LoseMinigame();
        GameManager.instance.GoToRewardScene();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PausedGame()
    {
        if (!isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }
}
