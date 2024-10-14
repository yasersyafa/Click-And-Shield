using UnityEngine;
using undanganApk;
public class LoseState : IMinigameState
{
    private MinigameStateManager minigame3Manager;

    public LoseState(MinigameStateManager manager)
    {
        minigame3Manager = manager;
    }

    public void EnterState()
    {
        Debug.Log("You lose!");

        // Call TriggerLose from GameManager and pass the lose animation clip
        // minigame3Manager.gameManager.TriggerLose(minigame3Manager.loseClip);
        GameManager.instance.LoseMinigame();
        GameManager.instance.GoToRewardScene();
    }

    public void UpdateState() { }

    public void ExitState() { }
}
