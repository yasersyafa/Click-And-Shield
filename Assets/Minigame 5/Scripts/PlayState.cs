using UnityEngine;
using lindungiDataPribadi;

namespace lindungiDataPribadi
{
    public class PlayState : IMinigameState
    {
        private MinigameStateManager minigameManager;
        private bool isGamePaused = false;

        public PlayState(MinigameStateManager manager)
        {
            minigameManager = manager;
            
        }

        public void EnterState()
        {
            Debug.Log(minigameManager.isGamePaused);
            SpawnTrojan();
            
        }

        public void UpdateState()
        {
            // Decrease the timer
            
            if(!minigameManager.isGamePaused) 
            {
                // Check Lose condition 
                if (Timer.instance.currentTimer <= 0)
                {
                    minigameManager.SetState(new LoseState(minigameManager));
                }

                // Check Win condition (check if the TrojanParent has no Child remainin = win)
                if (minigameManager.trojanParent.transform.childCount == 0)
                {
                    minigameManager.SetState(new WinState(minigameManager));
                }

            }
        }

        public void ExitState() { }

        void SpawnTrojan()
        {
            // Determine how many trojans to spawn between minTrojan and maxTrojan
            int trojanCount = Random.Range(minigameManager.minTrojan, minigameManager.maxTrojan + 1);

            // Loop to instantiate the determined number of trojans
            for (int i = 0; i < trojanCount; i++)
            {
                // Instantiate the trojanPrefab as a child of trojanParent with default position and rotation
                GameObject trojan = GameObject.Instantiate(minigameManager.trojanPrefab, minigameManager.trojanParent.transform);

                // Randomize position within the range (-3, 3) for x and (3, -3) for y
                Vector2 randomPosition = new Vector2(Random.Range(-200f, 200f), Random.Range(100f, -50f));

                // Set the position of the instantiated trojan
                trojan.transform.localPosition = randomPosition; // Use localPosition since it's a child
            }
        }
    }
}
