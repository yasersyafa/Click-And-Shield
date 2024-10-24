using UnityEngine;
using UnityEngine.Video;

namespace tangkapPhiser
{
public class LoseState : IMinigameState
{
    private MinigameStateManager minigameManager;
    

    public LoseState(MinigameStateManager manager)
    {
        minigameManager = manager;
    }

    public void EnterState()
    {
        AudioManager.StopMusic();
        minigameManager.cutsceneCanvas.SetActive(true);
        minigameManager.cutscenePlayer.clip = minigameManager.loseClip;
        minigameManager.cutscenePlayer.Play();
        minigameManager.cutscenePlayer.loopPointReached += EndLoseCutscene;

        // Call TriggerLose from GameManager and pass the lose animation clip
        // minigame3Manager.gameManager.TriggerLose(minigame3Manager.loseClip);
        
        
    }

    public void UpdateState() { }

    public void ExitState() { }

    private void EndLoseCutscene(VideoPlayer vp)
    {
        minigameManager.cutscenePlayer.loopPointReached -= EndLoseCutscene;
        Debug.Log("You lose!");
        GameManager.instance.LoseMinigame();
        GameManager.instance.GoToRewardScene();
    }
}

}
