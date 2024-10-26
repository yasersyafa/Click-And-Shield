using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using backupData;
using DG.Tweening;

namespace backupData
{
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;
        public Image loadingBackupBar;
        public RectTransform[] tutorialText;
        
        public GameObject cutsceneCanvas;
        public VideoPlayer cutscenePlayer;
        public VideoClip winClip, loseClip;

        public bool isGamePaused = false;
        private AudioManager audioManager;
        [SerializeField] private AudioClip sfx;
        private GameManager gameManager;
        // public AnimationClip winClip;
        // public AnimationClip loseClip;

        //* PlayState variables

        void Start()
        {
            tutorialText[0].DOAnchorPos(new Vector2(tutorialText[0].anchoredPosition.x, -38f), 0.2f);
            tutorialText[1].DOAnchorPos(new Vector2(tutorialText[1].anchoredPosition.x, -67f), 0.5f);
            gameManager = GameManager.instance;
            audioManager = FindObjectOfType<AudioManager>();
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
            audioManager.SetSFX(sfx);
            loadingBackupBar.fillAmount += 0.17f;
        }

        public void DecreaseLoadingBackup()
        {
            // decrease the fillAmount delta time
            loadingBackupBar.fillAmount -= Time.deltaTime;
        }
    }

}
