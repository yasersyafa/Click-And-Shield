using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOK : MonoBehaviour
{
    public GameObject disabledObject;
    public TextMeshProUGUI countdown;
    public Button buttonOK;
    public Image outline;
    float timer = 3f;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        currentTime = timer;
        ActivateTimer();
    }

    void ActivateTimer()
    {
        buttonOK.interactable = false;
        disabledObject.SetActive(true);
        StartCoroutine(TimerCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TimerCoroutine()
    {
        
        while(currentTime > 0)
        {
            countdown.text = Mathf.Ceil(currentTime).ToString();
            outline.fillAmount = currentTime / timer;
            currentTime -= Time.deltaTime;
            yield return null;
        }
        buttonOK.interactable = true;
        disabledObject.SetActive(false);
    }
}
