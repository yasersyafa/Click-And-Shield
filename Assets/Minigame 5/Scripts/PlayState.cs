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
                GameObject trojan = Object.Instantiate(minigameManager.trojanPrefab, minigameManager.trojanParent.transform);
                RectTransform trojanRect = trojan.GetComponent<RectTransform>();

                // calculate safe area
                Rect safe = Screen.safeArea;

                float xMin = safe.xMin - 50;
                float xMax = safe.xMax - 50;

                float yMin = safe.yMin - 50;
                float yMax = safe.yMax - 50;

                // Randomize position within the range (-3, 3) for x and (3, -3) for y
                Vector2 randomPosition = new(Random.Range(-100f, 100f), Random.Range(100f, -50f));
                // Vector2 randomPos = new(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

                // Set the position of the instantiated trojan
                trojan.transform.localPosition = randomPosition; // Use localPosition since it's a child
            }
        }
    }
}
