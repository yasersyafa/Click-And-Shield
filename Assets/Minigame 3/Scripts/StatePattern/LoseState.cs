using UnityEngine;
using UnityEngine.Video;
using undanganApk;
public class LoseState : IMinigameState
{
    private MinigameStateManager minigameManager;

    public LoseState(MinigameStateManager manager)
    {
        minigameManager = manager;
    }

    public void EnterState()
    {
        minigameManager.cutsceneCanvas.SetActive(true);
        minigameManager.cutscenePlayer.clip = minigameManager.loseClip;
        minigameManager.cutscenePlayer.Play();
        minigameManager.cutscenePlayer.loopPointReached += EndLoseCutscene;

        // Call TriggerLose from GameManager and pass the lose animation clip
        // minigame3Manager.gameManager.TriggerLose(minigame3Manager.loseClip);
        GameManager.instance.LoseMinigame();
    }

    public void UpdateState() { }

    public void ExitState() { }

    private void EndLoseCutscene(VideoPlayer vp)
    {
        minigameManager.cutscenePlayer.loopPointReached -= EndLoseCutscene;
        Debug.Log("You lose!");
        GameManager.instance.GoToRewardScene();
    }
}
