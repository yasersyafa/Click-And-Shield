using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace dataRush {
    public class PlayState : IMinigameState
    {
        private MinigameStateManager stateManager;
        

        public PlayState(MinigameStateManager manager) {
            stateManager = manager;
        }

        public void EnterState()
        {
            
        }

        public void UpdateState()
        {
            if(!stateManager.isGamePaused) {
                if(Timer.instance.currentTimer > 0) {
                    stateManager.draggableObject.enabled = true;
                }
                if(Timer.instance.currentTimer <= 0) {
                    stateManager.draggableObject.enabled = false;
                    stateManager.SetState(new dataRush.LoseState(stateManager));
                }
            }
        }

        public void ExitState()
        {
            
        }
        
    }
}
