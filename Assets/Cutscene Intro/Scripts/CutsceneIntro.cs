using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CutsceneIntro : MonoBehaviour
{
    public VideoPlayer vp;
    public Image skipIndicator;
    public Animator animatorTransition;
    public Button skipButton; // Add reference to the skip button
    
    private bool isButtonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        vp.loopPointReached += OnEndcutscene;
        
        // Set up button event listeners for hold detection
        if (skipButton != null)
        {
            EventTrigger trigger = skipButton.gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = skipButton.gameObject.AddComponent<EventTrigger>();
            }
            
            // Add pointer down event
            EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
            pointerDownEntry.eventID = EventTriggerType.PointerDown;
            pointerDownEntry.callback.AddListener((data) => { OnButtonDown(); });
            trigger.triggers.Add(pointerDownEntry);
            
            // Add pointer up event
            EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
            pointerUpEntry.eventID = EventTriggerType.PointerUp;
            pointerUpEntry.callback.AddListener((data) => { OnButtonUp(); });
            trigger.triggers.Add(pointerUpEntry);
            
            // Add pointer exit event (in case user drags off button)
            EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry();
            pointerExitEntry.eventID = EventTriggerType.PointerExit;
            pointerExitEntry.callback.AddListener((data) => { OnButtonUp(); });
            trigger.triggers.Add(pointerExitEntry);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for keyboard input OR button hold
        if(Input.GetKey(KeyCode.Return) || isButtonPressed)
        {
            skipIndicator.fillAmount += Time.deltaTime;
            if(skipIndicator.fillAmount >= 1)
            {
                StartCoroutine(ChangeSceneCoroutine());
                return;
            }
        }
        else
        {
            skipIndicator.fillAmount -= Time.deltaTime;
        }
    }
    
    private void OnButtonDown()
    {
        isButtonPressed = true;
    }
    
    private void OnButtonUp()
    {
        isButtonPressed = false;
    }

    private void OnEndcutscene(VideoPlayer videoPlayer)
    {
        vp.loopPointReached -= OnEndcutscene;
        vp.Stop();
        
        StartCoroutine(ChangeSceneCoroutine());
    }

    private IEnumerator ChangeSceneCoroutine()
    {
        animatorTransition.SetTrigger("Skip");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
