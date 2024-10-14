using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace typeProtect {
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;
        public TextMeshProUGUI currentText;
        public bool isGamePaused = false;
        public GameManager manager;
        
        // Start is called before the first frame update
        void Start()
        {
            manager = GameManager.instance;
            SetState(new typeProtect.PlayState(this));
        }

        public void SetState(IMinigameState newState) {
            currentState?.ExitState();
            currentState = newState;
            currentState?.EnterState();
        }

        // Update is called once per frame
        void Update()
        {  
            currentState?.UpdateState();
        }

        public void PauseGame() {
            isGamePaused = true;
            Time.timeScale = 0;
        }

        public void ResumeGame() {
            isGamePaused = false;
            Time.timeScale = 1;
        }
    }
}
