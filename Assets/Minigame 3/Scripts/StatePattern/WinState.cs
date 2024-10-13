using UnityEngine;
using undanganApk;

public class WinState : IMinigameState
{
    private MinigameStateManager minigameManager;

    public WinState(MinigameStateManager manager)
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
