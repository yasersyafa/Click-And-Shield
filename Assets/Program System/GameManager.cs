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

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int timer;
    private int currentScore;
    private int highScore;
    public Animator animator;
    public AchievementManager achievementManager;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        achievementManager = GetComponent<AchievementManager>();
        animator = GetComponent<Animator>();
        SetTimer(10);
        currentScore = 0;

        LoadData();
    }

    public int GetScore() {
        return currentScore;
    }


    // setter to set the timer
    public void SetTimer(int data) {
        timer = data;
    }

    // getter to get timer countdown
    public int GetTimer() {
        return timer;
    }

    public void UpdateTimer() {
        
        if(currentScore >= 500 && currentScore < 1000) {
            SetTimer(8);
        }
        else if(currentScore >= 1000 && currentScore < 1500) {
            SetTimer(7);
        }
        else if(currentScore >= 1500 && currentScore < 2000) {
            SetTimer(6);
        }
        else if(currentScore >= 2000) {
            SetTimer(5);
        }
        else {
            SetTimer(10);
        }
    }

    public int GetMinigameScene() {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int randomIndex = Random.Range(1, sceneCount);

        return randomIndex;
    }

    public void TriggerLose(AnimationClip loseClip) {
        animator.Play(loseClip.name);
    }

    public void TriggerWin(AnimationClip winClip) {
        currentScore++;
        UpdateTimer();
        animator.Play(winClip.name); 

        achievementManager.CheckForAchievement(currentScore);
        if(currentScore > highScore) {
            highScore = currentScore;
            SaveData();
        }
    }

    public void SaveData() {
        SaveManager.SaveGame(highScore, achievementManager.unlockedAchievements);
    }

    public void LoadData() {
        PlayerData data = SaveManager.LoadGame();
        if(data != null) {
            highScore = data.highScore;

            achievementManager.unlockedAchievements.Clear();
            foreach(var title in data.unlockedAchievements) {
                Achievement achievement = achievementManager.allAchievements.Find(a => a.title == title);
                if(achievement != null) {
                    achievementManager.unlockedAchievements.Add(achievement);
                }
            }
        }
    }
}
