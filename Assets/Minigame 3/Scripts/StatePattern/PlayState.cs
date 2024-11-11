using UnityEngine;
using undanganApk;
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
        PlayVibrateEffect();
        
    }

    public void UpdateState()
    {
        // Decrease the timer
        
        if(!minigameManager.isGamePaused) {
            // Check win condition 
            if (Timer.instance.currentTimer <= 0)
            {
                minigameManager.SetState(new WinState(minigameManager));
            }

            // check all any keyboard key is pressed
            if (Input.anyKeyDown && !Input.GetMouseButton(0))
            {
                minigameManager.SetState(new LoseState(minigameManager)); // Trigger lose on keyboard input
            }
        }
    }

    public void ExitState() { }

    void PlayVibrateEffect()
    {
        minigameManager.effect1.SetActive(true);
        minigameManager.effect2.SetActive(true);
    }
}
