using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace typeProtect {
    public class WinState : IMinigameState
    {
        private MinigameStateManager stateManager;
        public WinState(MinigameStateManager manager) {
            stateManager = manager;
        }
        public void EnterState()
        {
            Debug.Log("You Win!");
            stateManager.manager.WinMinigame();
            stateManager.manager.GoToRewardScene();
        }
        public void UpdateState()
        {
            
        }

        public void ExitState()
        {
            
        }

    }
}
