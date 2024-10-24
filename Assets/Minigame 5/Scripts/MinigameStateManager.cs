using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using DG.Tweening;

namespace lindungiDataPribadi
{
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;

        public GameObject trojanParent;
        public GameObject trojanPrefab;
        public int maxTrojan = 5;
        public int minTrojan = 3;
        public RectTransform tutorialText;


        public GameObject cutsceneCanvas;
        public VideoPlayer cutscenePlayer;
        public VideoClip winClip, loseClip;
        public bool isGamePaused = false;

        private GameManager gameManager;
        // public AnimationClip winClip;
        // public AnimationClip loseClip;
        //* PlayState variables

        void Start()
        {
            tutorialText.DOAnchorPos(new Vector2(tutorialText.anchoredPosition.x, -135f), 0.3f);
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

        public void QuitGame()
        {
            GameManager.instance.QuitGame();
        }
    }
}
