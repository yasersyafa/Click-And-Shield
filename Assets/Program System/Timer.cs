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
    GameManager manager;

    void Awake() {
        instance = this;
        
        manager = GameManager.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        countdown = manager != null ? manager.GetTimer() : 10f;
        currentTimer = countdown;
        barTimer.fillAmount = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer > 0) {
            currentTimer -= Time.deltaTime;
            barTimer.fillAmount = currentTimer / countdown;
        }
        else if(currentTimer <= 0) {
            barTimer.fillAmount = 0;        
        }

    }
}
