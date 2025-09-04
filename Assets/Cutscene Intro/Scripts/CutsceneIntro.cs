using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneIntro : MonoBehaviour
{
    public VideoPlayer vp;
    public Image skipIndicator;
    public Animator animatorTransition;
    // Start is called before the first frame update
    void Start()
    {
        vp.loopPointReached += OnEndcutscene;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
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
