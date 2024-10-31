using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    public void SetSound(AudioClip clip) {
    AudioManager.instance.SetSFX(clip);
    }
}   
