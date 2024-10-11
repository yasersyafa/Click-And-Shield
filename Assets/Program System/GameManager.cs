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
    private int winstreak;
    public Animator animator;

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
        animator = GetComponent<Animator>();
        SetTimer(10);
        winstreak = 0;
    }


    // setter to set the timer
    public void SetTimer(int data) {
        timer = data;
    }

    // getter to get timer countdown
    public int GetTimer() {
        return timer;
    }

    public void UpdateData() {
        winstreak++;
        if(winstreak >= 5 && winstreak < 10) {
            SetTimer(8);
        }
        else if(winstreak >= 10 && winstreak < 15) {
            SetTimer(7);
        }
        else if(winstreak >= 15 && winstreak < 20) {
            SetTimer(6);
        }
        else if(winstreak >= 20) {
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
        UpdateData();
        animator.Play(winClip.name); 
    }
}
