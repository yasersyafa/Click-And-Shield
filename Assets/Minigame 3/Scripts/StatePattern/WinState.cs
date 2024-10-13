using UnityEngine;

public class WinState : IMinigameState
{
    private Minigame3StateManager minigameManager;

    public WinState(Minigame3StateManager manager)
    {
        minigameManager = manager;
    }

    public void EnterState()
    {
        Debug.Log("You win!");

        // Call TriggerWin from GameManager and pass the win animation clip
        // minigameManager.gameManager.TriggerWin(minigameManager.winClip);
    }

    public void UpdateState() { }

    public void ExitState() { }
}
