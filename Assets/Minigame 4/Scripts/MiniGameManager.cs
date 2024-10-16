using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public GameObject gameoverPanel;
    public GameObject pausePanel;

    private bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
    
    public void GameOver()
    {
        gameoverPanel.SetActive(true);

        Time.timeScale = 0f;
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
        Application.Quit();
        Debug.Log("Aplikasi keluar");
    }
}
