using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace typeProtect {
    public class LoseState : IMinigameState
    {
        private MinigameStateManager stateManager;
        public LoseState(MinigameStateManager manager) {
            stateManager = manager;
        }
        public void EnterState()
        {
            Debug.Log("You Lose!");
            stateManager.manager.GoToRewardScene();
        }

        public void ExitState()
        {
            
        }

        public void UpdateState()
        {
            
        }
    }

}
