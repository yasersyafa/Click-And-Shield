using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [Space]
    [Header("music")]
    public List<AudioClip> musicClips = new();
    [Space]
    [Header("sfx")]
    public List<AudioClip> sfxClips = new();
    
    public void SetMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void SetSFX(AudioClip clip) {
        sfxSource.clip = clip;
        sfxSource.PlayOneShot(clip);
    }
}
