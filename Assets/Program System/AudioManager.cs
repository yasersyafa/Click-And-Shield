using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
use this Audio Manager script in every scene if you want play the audio
this script is reusable

*/


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

    public static AudioManager instance; //* UPDATE !!! - static instance
    

    public void SetMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();

        if(GameManager.instance != null) {
            if(GameManager.instance.playerScore >= 300 && GameManager.instance.playerScore < 700) {
                musicSource.pitch = 1.2f;
            }
            else if(GameManager.instance.playerScore >= 700 && GameManager.instance.playerScore < 1000) {
                musicSource.pitch = 1.3f;
            }
            else if(GameManager.instance.playerScore >= 1000 && GameManager.instance.playerScore < 1200) {
                musicSource.pitch = 1.4f;
            }
            else if(GameManager.instance.playerScore >= 1200) {
                musicSource.pitch = 1.5f;
            }
            
        }
    }

    void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        SetMusic(musicSource.clip);
    }

    public void SetSFX(AudioClip clip) {
        sfxSource.clip = clip;
        sfxSource.PlayOneShot(clip);
    }

    public static void StopMusic() {
        instance.musicSource.Stop();
    }

    public static void StopSfx()
    {
        instance.sfxSource.Stop();
    }


}
