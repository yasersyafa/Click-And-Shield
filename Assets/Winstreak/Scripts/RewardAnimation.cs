using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this for TMP components

public class RewardAnimation : MonoBehaviour
{
    public GameObject rewardPanel;
    public GameObject starBg;
    public GameObject cardAchievement;
    public GameObject clickToNext_Text; // This is the TMP text object

    public bool isCardRevealed = true;

    private Image rewardPanelImage;
    private RectTransform cardRectTransform;
    private Color originalCardColor;

    // Reference to the TextMeshProUGUI component
    private TextMeshProUGUI clickToNextTMPText;
    private AchievementManager achievement;

    void Start()
    {
        // find achievement manager component
        achievement = FindObjectOfType<AchievementManager>();
        // Assuming rewardPanel has an Image component for opacity animation
        rewardPanelImage = rewardPanel.GetComponent<Image>();

        // Get the TextMeshProUGUI component from clickToNext_Text GameObject
        clickToNextTMPText = clickToNext_Text.GetComponent<TextMeshProUGUI>();

        cardRectTransform = cardAchievement.GetComponent<RectTransform>();
        originalCardColor = cardAchievement.GetComponent<Image>().color;
        ShowRewardPanel();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isCardRevealed)
        {
            ClickToNextAnimation();
            isCardRevealed = true;
        }
    }

    public void ShowRewardPanel()
    {
        if(achievement.rewardQueue.Count >= 1) {
            rewardPanel.SetActive(true);
            StartCoroutine(AnimateRewardPanel(achievement.rewardQueue.Dequeue()));
            StarBgAnimation(); // Start the star background animation (continuous)
        }
    }

    private IEnumerator AnimateRewardPanel(Achievement badge)
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Color targetColor = rewardPanelImage.color;
        targetColor.a = 220f / 255f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alphaValue = Mathf.Lerp(0, 220f / 255f, elapsedTime / duration);
            rewardPanelImage.color = new Color(targetColor.r, targetColor.g, targetColor.b, alphaValue);
            yield return null;
        }

        rewardPanelImage.color = targetColor;
        StartCoroutine(CardAchievementAnimation(badge));
    }

    public void StarBgAnimation()
    {
        StartCoroutine(AnimateStarBg());
    }

    private IEnumerator AnimateStarBg()
    {
        float rotationSpeed = 90f;
        float scaleSpeed = 0.5f;
        float scaleAmount = 0.2f;

        Vector3 originalScale = starBg.transform.localScale;
        Vector3 targetScale = new Vector3(originalScale.x - scaleAmount, originalScale.y - scaleAmount, originalScale.z);
        float t = 0f;

        while (true)
        {
            starBg.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            t += scaleSpeed * Time.deltaTime;
            float scaleFactor = Mathf.PingPong(t, 1);
            starBg.transform.localScale = Vector3.Lerp(originalScale, targetScale, scaleFactor);
            yield return null;
        }
    }

    public IEnumerator CardAchievementAnimation(Achievement badge)
    {
        isCardRevealed = false;
        float moveDuration = 0.5f;
        Vector3 originalPosition = cardRectTransform.anchoredPosition;
        Vector3 targetPosition = new Vector3(originalPosition.x, 0, 0);
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            cardRectTransform.anchoredPosition = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            yield return null;
        }

        cardRectTransform.anchoredPosition = targetPosition;

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        yield return StartCoroutine(ShakeCard());
        StartCoroutine(FadeToColor(cardAchievement, Color.white, 0.5f, badge));
    }

    private IEnumerator ShakeCard()
    {
        float shakeDuration = 0.5f;
        float shakeAmount = 20f;
        float elapsedTime = 0f;
        Vector3 originalPosition = cardRectTransform.anchoredPosition;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float xOffset = Mathf.Sin(elapsedTime * Mathf.PI * 10) * shakeAmount;
            cardRectTransform.anchoredPosition = originalPosition + new Vector3(xOffset, 0, 0);
            yield return null;
        }

        cardRectTransform.anchoredPosition = originalPosition;

    }

    private IEnumerator FadeToColor(GameObject targetObject, Color targetColor, float duration, Achievement badge)
    {
        Image targetImage = targetObject.GetComponent<Image>();
        targetImage.sprite = badge.card;
        Color startColor = targetImage.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            targetImage.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            yield return null;
        }

        clickToNext_Text.SetActive(true);
        isCardRevealed = false; // Allow interaction again
    }

    // Updated to handle TextMeshProUGUI component
    public void ClickToNextAnimation()
    {
        StartCoroutine(FadeTextOpacity());
        clickToNext_Text.SetActive(true);
    }

    // Fade opacity for TextMeshProUGUI
    private IEnumerator FadeTextOpacity()
    {
        float fadeDuration = 0.8f;
        float minAlpha = 90f / 255f;
        float maxAlpha = 1f;

        while (true)
        {
            float elapsedTime = 0f;
            Color startColor = clickToNextTMPText.color;
            Color targetColor = startColor;
            targetColor.a = minAlpha;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alphaValue = Mathf.Lerp(maxAlpha, minAlpha, elapsedTime / fadeDuration);
                clickToNextTMPText.color = new Color(startColor.r, startColor.g, startColor.b, alphaValue);
                yield return null;
            }

            elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alphaValue = Mathf.Lerp(minAlpha, maxAlpha, elapsedTime / fadeDuration);
                clickToNextTMPText.color = new Color(startColor.r, startColor.g, startColor.b, alphaValue);
                yield return null;
            }
        }
    }
}
