using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
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
    private Queue<string> scenes = new();
    public bool isWin;
    public int playerScore = 0;
    private int highScore = 0;
    public bool isGamePaused = false;
    private float minigameTimer = 10f;
    public GameObject popUpModal;

    private string[] minigames = {"Minigame3", "Minigame2", "Minigame6", "Minigame1", "Minigame4", "Minigame5"};

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
        PopUp(popUpModal);
        LoadGame();
    }

    public float GetTimer() {
        return minigameTimer;
    }

    public int GetPlayerScore() {
        return playerScore;
    }

    public void GetMinigames() {
        if(isGamePaused) return;
        if(scenes.Count == 0) {
            AddQueue();
        }
        string minigame = scenes.Dequeue();
        SceneManager.LoadScene(minigame);
    }

    public void QuitGame() {
        

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

        if(playerScore >= 300 && playerScore < 700) {
            minigameTimer = 7f;
        }
        else if(playerScore >= 700) {
            minigameTimer = 5f;
        }
        else if(playerScore >= 1000) {
            minigameTimer = 3f;
        }
        else {
            minigameTimer = 10f;
        }
    }

    public void LoseMinigame() {
        highScore = playerScore > highScore ? playerScore : highScore;
        achievementManager.CheckForAchievement(playerScore);
        SaveManager.SaveGame(highScore, achievementManager.GetUnlockedAchievements());
        isWin = false;   
    }

    public void GoToRewardScene() {
        SceneManager.LoadScene("Winstreak");
    }

    public void LoadGame() {
        // Memuat data game dan pencapaian dari SaveManager
        PlayerData data = SaveManager.LoadGame();
        if (data != null) {
            highScore = data.highScore;
            achievementManager.LoadAchievements(data.achievements);  // Memuat pencapaian yang tersimpan
        }
        else {
            PopUp(popUpModal);
        }
    }

    private void AddQueue() {
        System.Random randomizeScene = new();
        minigames = minigames.OrderBy(x => randomizeScene.Next()).ToArray();
        foreach(string nameScene in minigames) {
            scenes.Enqueue(nameScene);
        }
    }

    private void PopUp(GameObject modalObject) {
        modalObject.SetActive(true);
        GameObject popup = modalObject.transform.GetChild(1).gameObject;
        popup.transform.DOLocalMoveY(0f, 1f);
    }

    public void ClosePopUp(GameObject modalObject) {
        GameObject popup = modalObject.transform.GetChild(1).gameObject;
        StartCoroutine(ClosePopUpCoroutine(popup));
    }

    private IEnumerator ClosePopUpCoroutine(GameObject objectToClose) {
        objectToClose.transform.DOLocalMoveY(-370f, 1f);
        yield return new WaitForSeconds(1f);
        objectToClose.transform.parent.gameObject.SetActive(false);
    }
}