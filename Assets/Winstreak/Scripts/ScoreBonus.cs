using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBonus : MonoBehaviour
{
    private GameObject _bonusScoreObject;
    void OnEnable() => GameManager.instance.onSevenHundred += ActivateGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable() => GameManager.instance.onSevenHundred -= ActivateGameObject;

    private void ActivateGameObject() {
        _bonusScoreObject = gameObject.transform.GetChild(0).gameObject;

        _bonusScoreObject.SetActive(true);
    }
}
