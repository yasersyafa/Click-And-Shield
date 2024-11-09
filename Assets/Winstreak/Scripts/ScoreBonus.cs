using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBonus : MonoBehaviour
{
    public GameObject bonusScoreObject;
    public TextMeshProUGUI bonusText;
    int bonusPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        bonusText.text = string.Empty;
        bonusPoint = GameManager.instance.bonusScore;
        ActivateGameObject();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }


    private void ActivateGameObject() {
        if(GameManager.instance.isWin && GameManager.instance.playerScore >= 700) { 
            bonusScoreObject.SetActive(true);
            bonusText.text = $"+{bonusPoint}";
            StartCoroutine(ScoreBonusCoroutine());
        }
        else {
            bonusScoreObject.SetActive(false);
        }
    }

    private IEnumerator ScoreBonusCoroutine() {
        float elapsedTime = 0f;
        while(elapsedTime < 1f) {
            elapsedTime += Time.deltaTime;

            int newScore = Mathf.FloorToInt(Mathf.Lerp(bonusPoint, 0, elapsedTime / 1f));

            bonusText.text = $"+{newScore}";

            yield return null;
        }

        bonusText.text = "+0";
    }
}
