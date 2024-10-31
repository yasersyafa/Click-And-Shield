using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace typeProtect {
    public class PlayState : IMinigameState
    {
        private MinigameStateManager stateManager;
        private string currentWord;
        private WordBank wordBank;

        public PlayState (MinigameStateManager manager) {
            stateManager = manager;
            wordBank = stateManager.gameObject.GetComponent<WordBank>();
        }
        public void EnterState()
        {
            Debug.Log(stateManager.isGamePaused);
            currentWord = wordBank.GetTargetWord();
            stateManager.currentText.text = currentWord;
        }

        

        public void UpdateState()
        {
            if(!stateManager.isGamePaused) {
                if(Timer.instance.currentTimer > 0) {
                    PlayerController();
                }
                else if(Timer.instance.currentTimer <= 0) {
                    stateManager.SetState(new LoseState(stateManager));
                }
            }
        }

        public void ExitState()
        {
            
        }

        private void PlayerController() {
            if(Input.anyKeyDown) {
                string inputChar = Input.inputString;
                if(!string.IsNullOrEmpty(inputChar)) {
                    CheckInput(inputChar);
                }
            }
        }

        private void CheckInput(string input) {
            if(input == currentWord[0].ToString()){
                RemoveLetter();
            }
        }

        private void RemoveLetter() {
            AudioManager audioManager = GameObject.FindObjectOfType<AudioManager>();
            audioManager.SetSFX(audioManager.sfxClips[0]);
            currentWord = currentWord[1..];
            stateManager.currentText.text = currentWord;
            if(currentWord.Length == 0) {
                stateManager.SetState(new WinState(stateManager));
            }
        }
    }
}
