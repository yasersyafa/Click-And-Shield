using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
namespace undanganApk
{
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;
        public GameObject cutsceneCanvas;
        public VideoPlayer cutscenePlayer;
        public VideoClip winClip, loseClip;
        public bool isGamePaused = false;
        public RectTransform[] tutorialText;

        // public GameObject effect1;
        // public GameObject effect2;

        private GameManager gameManager;
        // public AnimationClip winClip;
        // public AnimationClip loseClip;

        //* PlayState variables

        void Start()
        {
            tutorialText[0].DOAnchorPos(new Vector2(40f, tutorialText[0].anchoredPosition.y), 0.3f);
            tutorialText[1].DOAnchorPos(new Vector2(-20f, tutorialText[1].anchoredPosition.y), 0.4f);
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
