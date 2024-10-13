using UnityEngine;

public class LoseState : IMinigameState
{
    private Minigame3StateManager minigame3Manager;

    public LoseState(Minigame3StateManager manager)
    {
        minigame3Manager = manager;
    }

    public void EnterState()
    {
        Debug.Log("You lose!");

        // Call TriggerLose from GameManager and pass the lose animation clip
        // minigame3Manager.gameManager.TriggerLose(minigame3Manager.loseClip);
    }

    public void UpdateState() { }

    public void ExitState() { }
}
