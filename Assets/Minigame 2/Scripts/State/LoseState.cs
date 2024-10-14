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
            stateManager.cutscene.SetActive(true);
            stateManager.animator.SetTrigger("Lose");
            GameManager.instance.LoseMinigame();
            // if(stateManager.cutscene.activeSelf) {
            //     // play animation
            // }
            // stateManager.manager.GoToRewardScene();
        }

        public void ExitState()
        {
            
        }

        public void UpdateState()
        {
            
        }
    }

}
