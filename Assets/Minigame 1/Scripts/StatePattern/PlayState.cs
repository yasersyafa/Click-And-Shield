using UnityEngine;

namespace tangkapPhiser
{
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
        
        }

        public void ExitState() { }
    }
}
