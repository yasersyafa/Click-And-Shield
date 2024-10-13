using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Image barTimer;
    private float countdown;
    public float currentTimer;
    public bool isFinished;
    GameManager manager;

    void Awake() {
        instance = this;
        isFinished = false;
        manager = GameManager.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        countdown = manager != null ? manager.GetTimer() : 10f;
        Debug.Log(countdown);
        currentTimer = countdown;
        barTimer.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer > 0 && !isFinished) {
            currentTimer -= Time.deltaTime;
            barTimer.fillAmount = currentTimer / countdown;
        }
        else if(currentTimer <= 0 && !isFinished) {
            barTimer.fillAmount = 0;
            
        }
    }

    public void TriggerWin() {
        isFinished = true;
        // manager.TriggerWin();
        Debug.Log("Win");
    }

    public void TriggerLose() {
        isFinished = true;
        // manager.TriggerLose();
        Debug.Log("Lose");
    }

    
}
