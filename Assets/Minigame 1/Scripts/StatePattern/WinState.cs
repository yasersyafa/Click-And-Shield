using UnityEngine;
using UnityEngine.Video;
using tangkapPhiser;

namespace tangkapPhiser
{
    public class WinState : IMinigameState
    {
        private MinigameStateManager minigameManager;
        

        public WinState(MinigameStateManager manager)
        {
            minigameManager = manager;
        }

        public void EnterState()
        {
            minigameManager.cutsceneCanvas.SetActive(true);
            minigameManager.cutscenePlayer.clip = minigameManager.winClip;
            minigameManager.cutscenePlayer.Play();
            minigameManager.cutscenePlayer.loopPointReached += EndWinCutscene;

            // Call TriggerWin from GameManager and pass the win animation clip
            // minigameManager.gameManager.TriggerWin(minigameManager.winClip);
            GameManager.instance.WinMinigame();
            

        }

        public void UpdateState() { 
            
            
        }

        public void ExitState() { }

        private void EndWinCutscene(VideoPlayer vp)
        {
            minigameManager.cutscenePlayer.loopPointReached -= EndWinCutscene;
            Debug.Log("Win cutscene ended.");
            GameManager.instance.GoToRewardScene();
        }
    }
}
