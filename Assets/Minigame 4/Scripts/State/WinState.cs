using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace dataRush {
    public class WinState : IMinigameState
    {
        private MinigameStateManager stateManager;

        public WinState(MinigameStateManager manager) {
            stateManager = manager;
        }
        public void EnterState()
        {
            // AudioManager.StopMusic();
            stateManager.cutsceneCanvas.SetActive(true);
            stateManager.cutscenePlayer.clip = stateManager.winClip;
            stateManager.cutscenePlayer.Play();
            stateManager.cutscenePlayer.loopPointReached += EndWinCutscene;
            
        }

        public void UpdateState()
        {
            
        }

        public void ExitState()
        {
            
        }

        private void EndWinCutscene(VideoPlayer vp) {
            stateManager.cutscenePlayer.loopPointReached -= EndWinCutscene;
            
            GameManager.instance.WinMinigame();
            GameManager.instance.GoToRewardScene();
        }
        
    }

}
