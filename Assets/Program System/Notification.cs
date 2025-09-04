using System.Collections;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public GameObject notificationText;
    public GameObject notificationText2;
    private CanvasGroup canvasGroup1;
    private CanvasGroup canvasGroup2;

    void Start()
    {
        // Get or add CanvasGroup components to both text GameObjects
        canvasGroup1 = notificationText.GetComponent<CanvasGroup>();
        if (canvasGroup1 == null)
        {
            canvasGroup1 = notificationText.AddComponent<CanvasGroup>();
        }

        canvasGroup2 = notificationText2.GetComponent<CanvasGroup>();
        if (canvasGroup2 == null)
        {
            canvasGroup2 = notificationText2.AddComponent<CanvasGroup>();
        }

        // Start with full opacity for both text objects
        canvasGroup1.alpha = 1f;
        canvasGroup2.alpha = 1f;

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
        StartCoroutine(FadeNotificationTexts());
    }

    private IEnumerator FadeNotificationTexts()
    {
        float fadeDuration = 2f;  // Duration of the fade effect
        float elapsedTime = 0f;

        // Target alpha value for the fade effect
        float targetAlpha = 0.53f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;

            // Fade opacity for both text objects over time
            canvasGroup1.alpha = Mathf.Lerp(1f, targetAlpha, t);
            canvasGroup2.alpha = Mathf.Lerp(1f, targetAlpha, t);

            yield return null;
        }

        // Ensure final alpha values are set at the end of animation
        canvasGroup1.alpha = targetAlpha;
        canvasGroup2.alpha = targetAlpha;
    }
}
