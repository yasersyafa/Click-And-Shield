using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
!!! ALERT !!!
- Do not modify the code except the author of the script
- Do not modify variable timer directly

- assign the script to game object in main menu scene

- use GetTimer() for get data timer each minigames
- use SetTimer(int data) if neccessary to modify data timer
- use GetMinigameScene() to get random minigames
- use TriggerWin() if win the minigame
- use TriggerLose() if lose the minigame
*/

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    private AchievementManager achievementManager;
    public bool isWin;
    public int playerScore = 0;
    private int highScore = 0;
    public bool isGamePaused = false;
    private float minigameTimer = 10f;

    private string[] minigames = {"Minigame3", "Minigame2"};

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    void Start() {
        achievementManager = GetComponentInChildren<AchievementManager>();
    }

    public float GetTimer() {
        return minigameTimer;
    }

    public int GetPlayerScore() {
        return playerScore;
    }

    public void GetMinigames() {
        if(isGamePaused) return;

        string minigame = minigames[Random.Range(0, minigames.Length)];
        SceneManager.LoadScene(minigame);
    }

    public void QuitGame() {
        highScore = playerScore > highScore ? playerScore : highScore;

        // reset all 
        playerScore = 0;
        minigameTimer = 10f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitApplication() {
        Application.Quit();
    }

    public void WinMinigame() {
        isWin = true;
        playerScore += 100;

        if(playerScore >= 500 && playerScore < 1000) {
            minigameTimer = 8f;
        }
        else if(playerScore >= 1000) {
            minigameTimer = 5f;
        }
        else {
            minigameTimer = 10f;
        }
    }

    public void LoseMinigame() {
        achievementManager.CheckForAchievement(playerScore);
        isWin = false;   
    }

    public void GoToRewardScene() {
        SceneManager.LoadScene("Winstreak");
    }

    public void WinAnimation() {
        Debug.Log("Win");
    }

    public void LoseAnimation() {
        Debug.Log("Lose");
    }
}