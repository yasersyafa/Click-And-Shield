using UnityEngine;
using UnityEngine.UI;
using backupData;

namespace backupData
{
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;
        public Image loadingBackupBar;
        public bool isGamePaused = false;

        private GameManager gameManager;
        // public AnimationClip winClip;
        // public AnimationClip loseClip;

        //* PlayState variables

        void Start()
        {
            gameManager = GameManager.instance;
            SetState(new PlayState(this)); // Start with the start animation state
        }

        void Update()
        {
            currentState?.UpdateState(); // Update the current state
        }

        public void SetState(IMinigameState newState)
        {
            currentState?.ExitState();
            currentState = newState;
            currentState.EnterState();
        }
        
        //* UI Functions
        public void PauseGame()
        {
            Time.timeScale = 0;
            isGamePaused = true;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            isGamePaused = false;
        }

        public void MainMenu()
        {
            GameManager.instance.QuitGame();
        }

        //* Minigame Functions
        public void PressedLoadingBackup()
        {
            loadingBackupBar.fillAmount += 0.2f;
        }

        public void DecreaseLoadingBackup()
        {
            // decrease the fillAmount delta time
            loadingBackupBar.fillAmount -= Time.deltaTime;
        }
    }

}
