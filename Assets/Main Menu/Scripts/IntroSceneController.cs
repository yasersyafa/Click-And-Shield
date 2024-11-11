using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class IntroSceneController : MonoBehaviour
{
    public GameObject SkipText;
    public GameObject SkipImage;
    public GameObject FadePanel;
    private VideoPlayer videoPlayer;
    private bool isWaitingToEnd = false; // To prevent multiple coroutine calls

    void Start()
    {
        // Get the VideoPlayer component
        videoPlayer = GetComponent<VideoPlayer>();

        // Subscribe to the loopPointReached event to detect when the video ends
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Update()
    {
        // Skip the video when the user presses the space key && SkipText fill amount is 1
        if (Input.GetKey(KeyCode.Space))
        {
            SkipImageFill();

            if (SkipImage.GetComponent<Image>().fillAmount == 1 && !isWaitingToEnd)
            {
                SkipText.SetActive(false);
                FadeInPanel();
                StartCoroutine(WaitAndEndVideo());
            }
        }
        else
        {
            ResetImageFill();
        }
    }

    IEnumerator WaitAndEndVideo()
    {
        isWaitingToEnd = true;
        yield return new WaitForSeconds(1f);
        OnVideoEnd(videoPlayer);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
        // Load the desired scene once the video finishes
        SceneManager.LoadScene("MainMenu"); // Replace with your scene's name
    }

    void SkipImageFill()
    {
        // Fill the skip image over deltaTime
        SkipImage.GetComponent<Image>().fillAmount += 0.5f * Time.deltaTime;
    }

    void ResetImageFill()
    {
        // Reset the fill amount of Skip image over deltaTime
        SkipImage.GetComponent<Image>().fillAmount -= 0.5f * Time.deltaTime;
        isWaitingToEnd = false; // Reset flag when user releases the space key
    }

    void FadeInPanel()
    {
        // Fade in the panel
        FadePanel.SetActive(true);

        // Fade the panel opacity from 0 to 1 over 1 second
        FadePanel.GetComponent<CanvasGroup>().DOFade(1, 1);
    }
}
