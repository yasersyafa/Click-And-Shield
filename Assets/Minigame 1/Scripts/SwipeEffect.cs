using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using tangkapPhiser;

public enum EmailType
{
    Fake,
    Real
}

public class SwipeEffect : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 _initialPosition;
    public EmailType emailType;
    public tangkapPhiser.MinigameStateManager minigameManager;
    public Transform imageAnchor;
    public GameObject greenBg, redBg;
    public bool isResetAble = true;
    
    void Start()
    {
        // Set imageAnchor to the current object's transform
        imageAnchor = transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store the initial position at the start of the drag
        _initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Allow swiping only left or right (modify x position)
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);
        if(imageAnchor.localPosition.x > 0)
        {
            // set background color to green
            greenBg.SetActive(true);
            redBg.SetActive(false);
        }
        else if(imageAnchor.localPosition.x < 0)
        {
            // set background color to red
            greenBg.SetActive(false);
            redBg.SetActive(true);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Start swipe animation if the position exceeds certain thresholds
        if(imageAnchor.localPosition.x <= -50 && emailType == EmailType.Real)
        {
            ResetPosition();
        }
        else if (imageAnchor.localPosition.x <= -50)
        {
            isResetAble = false;
            StartSwipeAnimation(-500); // Start animation moving left
        }
        else if (imageAnchor.localPosition.x >= 50)
        {
            isResetAble = false;
            StartSwipeAnimation(500); // Start animation moving right
        }
        else
        {
            // If the position is within the reset range, reset to the initial position
            if (isResetAble)
            {
                ResetPosition();
            }
        }
    }

    public void StartSwipeAnimation(float targetX)
    {
        // Smoothly move the object to the target x position
        StartCoroutine(SwipeToPosition(targetX));
    }

    private IEnumerator SwipeToPosition(float targetX)
    {
        while (Mathf.Abs(imageAnchor.localPosition.x - targetX) > 0.1f)
        {
            imageAnchor.localPosition = new Vector2(Mathf.Lerp(imageAnchor.localPosition.x, targetX, Time.deltaTime * 25), imageAnchor.localPosition.y);
            yield return null; // Wait for the next frame
        }
        // Ensure the object reaches the exact target position
        imageAnchor.localPosition = new Vector2(targetX, imageAnchor.localPosition.y);
        Destroy(transform.parent.gameObject);
        CheckEmail();
        
    }

    private void CheckEmail()
    {
        if(emailType == EmailType.Fake && imageAnchor.localPosition.x == 500)
        {
            // Call lose game
            minigameManager.SetState(new tangkapPhiser.LoseState(minigameManager));
        }
    }

    public void ResetPosition()
    {
        // Reset position to the initial position
        transform.localPosition = _initialPosition;
    }
}
