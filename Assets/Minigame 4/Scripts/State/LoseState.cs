using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace dataRush {
    public class LoseState : IMinigameState
    {
        private MinigameStateManager stateManager;
        public LoseState(MinigameStateManager manager) {
            stateManager = manager;
        }

        public void EnterState()
        {
            // AudioManager.StopMusic();
            stateManager.cutsceneCanvas.SetActive(true);
            stateManager.cutscenePlayer.clip = stateManager.loseClip;
            stateManager.cutscenePlayer.Play();
            stateManager.cutscenePlayer.loopPointReached += EndLoseCutscene;
            
        }

        public void UpdateState()
        {
            
        }

        public void ExitState()
        {
            
        }

        private void EndLoseCutscene(VideoPlayer vp) {
            stateManager.cutscenePlayer.loopPointReached -= EndLoseCutscene;
            Debug.Log("Win cutscene ended.");
            GameManager.instance.LoseMinigame();
            GameManager.instance.GoToRewardScene();
        }
    }

}
