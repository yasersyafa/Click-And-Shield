using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace typeProtect {
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

            // Call TriggerLose from GameManager and pass the lose animation clip
            // minigame3Manager.gameManager.TriggerLose(minigame3Manager.loseClip);
            
        }

        public void ExitState()
        {
            
        }

        public void UpdateState()
        {
            
        }

        private void EndLoseCutscene(VideoPlayer vp)
        {
            stateManager.cutscenePlayer.loopPointReached -= EndLoseCutscene;
            
            GameManager.instance.LoseMinigame();
            GameManager.instance.GoToRewardScene();
        }
    }

}
