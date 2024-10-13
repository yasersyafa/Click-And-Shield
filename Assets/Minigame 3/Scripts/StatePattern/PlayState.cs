using UnityEngine;
using undanganApk;

public class PlayState : IMinigameState
{
    private MinigameStateManager minigameManager;

    public PlayState(MinigameStateManager manager)
    {
        minigameManager = manager;
        
    }

    public void EnterState()
    {
        Debug.Log("Game started.");
    }

    public void UpdateState()
    {
        // Decrease the timer
        

        // Check win condition 
        if (Timer.instance.currentTimer <= 0)
        {
            minigameManager.SetState(new WinState(minigameManager));
        }

        // Check lose condition
        if (Input.anyKeyDown) // Left mouse button
        {
            minigameManager.SetState(new LoseState(minigameManager)); // Transition to lose state
        }
    }

    public void ExitState() { }
}
