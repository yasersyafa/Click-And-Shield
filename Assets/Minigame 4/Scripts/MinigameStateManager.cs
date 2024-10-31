using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

namespace dataRush {
    public class MinigameStateManager : MonoBehaviour
    {
        private IMinigameState currentState;
        private GameManager manager;
        public RectTransform tutorialText;
        public VideoPlayer cutscenePlayer;
        public VideoClip winClip, loseClip;
        public GameObject cutsceneCanvas;
        public DraggableObject draggableObject;
        public bool isGamePaused = false;
        // Start is called before the first frame update
        void Start()
        {
            tutorialText.DOAnchorPos(new Vector2(tutorialText.anchoredPosition.x, -50f), 0.2f);
            manager = GameManager.instance;
            draggableObject = FindObjectOfType<DraggableObject>();
            SetState(new dataRush.PlayState(this));
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

        public void QuitGame() {
            manager.QuitGame();
        }
    }

}
