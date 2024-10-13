using UnityEngine;
using UnityEngine.UI;

public class Minigame3StateManager : MonoBehaviour
{
    private IMinigameState currentState;

    public GameManager gameManager;
    // public AnimationClip winClip;
    // public AnimationClip loseClip;

    //* PlayState variables
    

    void Start()
    {
        gameManager = GameManager.instance;
        SetState(new PlayState(this)); // Start with the start animation state
    }

    void Update()
    {
        currentState?.UpdateState(); // Update the current state
    }

    public void SetState(IMinigameState newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
