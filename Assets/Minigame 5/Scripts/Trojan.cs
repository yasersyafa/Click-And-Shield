using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trojan : MonoBehaviour
{
    
    public void DestroyTrojan()
    {
        Destroy(gameObject);
    }

    public void OnClickExitButton() {
        AudioManager.instance.SetSFX(AudioManager.instance.sfxClips[0]);
    }
}
