using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace typeProtect {
    public class WinState : IMinigameState
    {
        private MinigameStateManager stateManager;
        public WinState(MinigameStateManager manager) {
            stateManager = manager;
        }
        public void EnterState()
        {
            AudioManager.StopMusic();
            stateManager.cutsceneCanvas.SetActive(true);
            stateManager.cutscenePlayer.clip = stateManager.winClip;
            stateManager.cutscenePlayer.Play();
            stateManager.cutscenePlayer.loopPointReached += EndWinCutscene;

            // Call TriggerWin from GameManager and pass the win animation clip
            // minigame3Manager.gameManager.TriggerWin(minigame3Manager.winClip);
            GameManager.instance.WinMinigame();
        }
        public void UpdateState()
        {
            
        }

        public void ExitState()
        {
            
        }

        private void EndWinCutscene(VideoPlayer vp)
        {
            stateManager.cutscenePlayer.loopPointReached -= EndWinCutscene;
            Debug.Log("Win cutscene ended.");
            GameManager.instance.GoToRewardScene();
        }

    }
}
