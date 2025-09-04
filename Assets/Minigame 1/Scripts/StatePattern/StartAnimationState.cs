using UnityEngine;

namespace tangkapPhiser
{
    public class StartAnimationState : IMinigameState
    {
        private MinigameStateManager minigameManager;

        public StartAnimationState(MinigameStateManager manager)
        {
            minigameManager = manager;
        }

        public void EnterState()
        {
            

            // Start your animation (this could be with Animator, or via an event/coroutine)
            // Example: minigameManager.gameManager.animator.Play("StartAnimation");

            // After the animation ends, transition to PlayState
            minigameManager.SetState(new PlayState(minigameManager));
        }

        public void UpdateState() { }

        public void ExitState() { }
    }
    
}
