using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;

namespace tangkapPhiser
{
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;
        public GameObject ParentEmail, cutsceneCanvas;
        public VideoPlayer cutscenePlayer;
        public VideoClip winClip, loseClip;
        public RectTransform[] tutorialText;
        
        public bool isGamePaused = false;

        private GameManager gameManager;

        //* PlayState variables

        void Start()
        {
            tutorialText[0].DOAnchorPos(new Vector2(34f, tutorialText[0].anchoredPosition.y), 0.5f);
            tutorialText[1].DOAnchorPos(new Vector2(-34f, tutorialText[1].anchoredPosition.y), 0.5f);
            // tutorialText[1].DOAnchorPosX(-34f, 0.5f);
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
            isGamePaused = true;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            isGamePaused = false;
        }

        public void LoseGame()
        {
            SetState(new LoseState(this));
        }
        public void QuitGame()
        {
            GameManager.instance.QuitGame();
        }
    }

}
