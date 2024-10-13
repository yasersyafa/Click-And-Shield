using UnityEngine;
namespace undanganApk
{
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;

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
        
        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void LoseGame()
        {
            SetState(new LoseState(this));
        }
        public void QuitGame()
        {
            gameManager.QuitGame();
        }
    }

}
