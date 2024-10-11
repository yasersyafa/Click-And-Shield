using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingManager : MonoBehaviour
{
    
    private string currentWord;
    public TextMeshProUGUI text;
    private WordBank wordBank;
    GameManager manager;
    private AudioManager audioManager;

    void Awake() {
        manager = GameManager.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        wordBank = GetComponent<WordBank>();
        currentWord = wordBank.GetTargetWord();
        text.text = currentWord;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Timer.instance.isFinished)
        {
            string inputChar = Input.inputString;

            if (!string.IsNullOrEmpty(inputChar))
            {
                CheckInput(inputChar);
            }
        }
    }

    

    public void CheckInput(string input) {
        if (input == currentWord[0].ToString()) // Check if input matches first letter of currentWord
        {
            RemoveLetter();
        }
    }

    public void RemoveLetter() {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.SetSFX(audioManager.sfxClips[0]);
        currentWord = currentWord[1..]; // Remove the first letter
        text.text = currentWord; // Update the word display

        if (currentWord.Length == 0)
        {
            Timer.instance.TriggerWin();
        }
    }
}
