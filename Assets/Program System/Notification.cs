using System.Collections;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public GameObject notificationText;
    private Vector3 originalScale;
    private CanvasGroup canvasGroup;

    void Start()
    {
        originalScale = notificationText.transform.localScale;
        canvasGroup = notificationText.GetComponent<CanvasGroup>();

        // Add CanvasGroup component if not already present
        if (canvasGroup == null)
        {
            canvasGroup = notificationText.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 1f; // Start with full opacity
        CheckNotification();
    }

    void CheckNotification()
    {
        if (GameManager.instance.hasNewItem)
        {
            gameObject.SetActive(true);
            NotificationAnimation(); // Trigger animation if there's a new item
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        gameObject.SetActive(false);
        GameManager.instance.hasNewItem = false;
    }

    public void NotificationAnimation() 
    {
        StartCoroutine(AnimateNotificationText());
    }

    private IEnumerator AnimateNotificationText()
    {
        float scaleDuration = 1f; // Duration of the scale effect
        float fadeDuration = 2f;  // Duration of the fade effect (slower)
        float elapsedTime = 0f;

        // Target scale for animation
        Vector3 targetScale = originalScale * 1.2f;

        while (elapsedTime < Mathf.Max(scaleDuration, fadeDuration))
        {
            elapsedTime += Time.deltaTime;

            // Scale over time
            float scaleT = Mathf.Clamp01(elapsedTime / scaleDuration);
            notificationText.transform.localScale = Vector3.Lerp(originalScale, targetScale, scaleT);

            // Fade over time
            float fadeT = Mathf.Clamp01(elapsedTime / fadeDuration);
            canvasGroup.alpha = Mathf.Lerp(1f, 0.53f, fadeT);

            yield return null;
        }

        // Ensure final values are set
        notificationText.transform.localScale = targetScale;
        canvasGroup.alpha = 0.53f;
    }
}
