using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class IntroSceneController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // Get the VideoPlayer component
        videoPlayer = GetComponent<VideoPlayer>();

        // Subscribe to the loopPointReached event to detect when the video ends
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the desired scene once the video finishes
        SceneManager.LoadScene("MainMenu"); // Replace with your scene's name
    }
}
