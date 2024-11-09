using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBonus : MonoBehaviour
{
    public GameObject bonusScoreObject;
    
    // Start is called before the first frame update
    void Start()
    {
        ActivateGameObject();
    }

    
    void OnDisable() { GameManager.instance.onSevenHundred -= ActivateGameObject; }
    

    // Update is called once per frame
    void Update()
    {
        
    }


    private void ActivateGameObject() {
        if(GameManager.instance.isWin && GameManager.instance.playerScore >= 700) { bonusScoreObject.SetActive(true); }
        else bonusScoreObject.SetActive(false);
    }
}
