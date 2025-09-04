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
            
            Shuffle();
        }

        public void UpdateState()
        {
            if(!minigameManager.isGamePaused) {
                if(Timer.instance.currentTimer <= 0) {
                    minigameManager.SetState(new LoseState(minigameManager));
                }
                else {
                    if(minigameManager.ParentEmail.transform.childCount == 0) {
                        minigameManager.SetState(new WinState(minigameManager));
                    }
                }
            }
        }

        public void ExitState() { }

        private void Shuffle()
        {
            // Shuffle the emails
            int n = minigameManager.ParentEmail.transform.childCount;
            GameObject[] emails = new GameObject[n];
            for (int i = 0; i < n; i++)
            {
                // get all the emails
                emails[i] = minigameManager.ParentEmail.transform.GetChild(i).gameObject;
            }
            for (int i = 0; i < n; i++)
            {
                // shuffle the emails
                GameObject temp = emails[i];
                int randomIndex = Random.Range(i, n);
                emails[i] = emails[randomIndex];
                emails[randomIndex] = temp;
            }
            for (int i = 0; i < n; i++)
            {
                // set the emails back to the parent
                emails[i].transform.SetSiblingIndex(i);
            }
            
        }
    }
}
