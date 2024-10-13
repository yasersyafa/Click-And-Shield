using UnityEngine;

public class StartAnimationState : IMinigameState
{
    private Minigame3StateManager minigameManager;

    public StartAnimationState(Minigame3StateManager manager)
    {
        minigameManager = manager;
    }

    public void EnterState()
    {
        Debug.Log("Start animation playing...");

        // Start your animation (this could be with Animator, or via an event/coroutine)
        // Example: minigameManager.gameManager.animator.Play("StartAnimation");

        // After the animation ends, transition to PlayState
        minigameManager.SetState(new PlayState(minigameManager));
    }

    public void UpdateState() { }

    public void ExitState() { }
}
