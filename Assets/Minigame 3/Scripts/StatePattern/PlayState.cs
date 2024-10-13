using UnityEngine;

public class PlayState : IMinigameState
{
    private Minigame3StateManager minigameManager;

    public PlayState(Minigame3StateManager manager)
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
