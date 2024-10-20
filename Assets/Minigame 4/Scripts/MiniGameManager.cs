using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MiniGameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject cutsceneCanvas; //* UPDATE !!!
    public VideoPlayer cutscenePlayer; //* UPDATE !!!
    public VideoClip winClip, loseClip; //* UPDATE !!!
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

    public void WinGame() //* UPDATE !!!
    {
        AudioManager.StopMusic();
        cutsceneCanvas.SetActive(true); 
        cutscenePlayer.clip = winClip;
        cutscenePlayer.Play();
        cutscenePlayer.loopPointReached += EndWinCutscene;
        GameManager.instance.WinMinigame();
        GameManager.instance.GoToRewardScene();
    }

    public void GameOver() //* UPDATE !!!
    {
        AudioManager.StopMusic();
        cutsceneCanvas.SetActive(true);
        cutscenePlayer.clip = loseClip;
        cutscenePlayer.Play();
        cutscenePlayer.loopPointReached += EndLoseCutscene;
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

    private void EndWinCutscene(VideoPlayer vp) //* UPDATE !!!
    {
        cutscenePlayer.loopPointReached -= EndWinCutscene;
        Debug.Log("Win cutscene ended.");
        GameManager.instance.GoToRewardScene();
    }

    public void EndLoseCutscene(VideoPlayer vp) //* UPDATE !!!
    {
        cutscenePlayer.loopPointReached -= EndLoseCutscene;
        Debug.Log("Lose cutscene ended.");
        GameManager.instance.GoToRewardScene();
    }
}
