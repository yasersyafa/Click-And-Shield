using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        CheckNotification();
    }

    void CheckNotification() {
        if(GameManager.instance.hasNewItem) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }

    public void OnButtonClick() {
        GameManager.instance.hasNewItem = false;
    }
}
