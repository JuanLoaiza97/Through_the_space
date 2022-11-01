using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public AudioMixer mixer;
    public AudioSource backgroundSound;

    [Header("Sonidos")]
    public AudioClip button;
    public AudioClip teleportation;
    public AudioClip gameOver;
    public AudioClip portal;
    public AudioClip aliens;
    public AudioClip coin;
    public AudioClip collision;
    public AudioClip firstAidKit;
    public AudioClip gabrielon;
    public AudioClip niviru5003;
    public AudioClip menuMusic;
    public AudioClip win;

    private AudioSource fxSource;
    private bool turnDownVolumeMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        fxSource = GetComponent<AudioSource>();
        turnDownVolumeMusic = false;
    }

    private void Update() 
    {
        if (turnDownVolumeMusic)
        {
            DownBackgroundMusic();
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        fxSource.PlayOneShot(audioClip);
    }

    public void PlayButtonSound()
    {
        fxSource.PlayOneShot(button);
    }

    public void PlayTeleportationSound()
    {
        PlaySound(teleportation);
    }

    public void PlayGameOverSound()
    {
        PlaySound(gameOver);
    }

    public void PlayCoinSound()
    {
        PlaySound(coin);
    }

    public void PlayFirstAidKitSound()
    {
        PlaySound(firstAidKit);
    }

    public void PlayCollisionSound()
    {
        PlaySound(collision);
    }

    public void SetBackgroundMusic(AudioClip audioClip)
    {
        backgroundSound.clip = audioClip;
        backgroundSound.Play();
    }

    public void StopBackgroundMusic()
    {
        backgroundSound.Stop();
    }

    public void ResetVolumeBackgroundMusic()
    {
        backgroundSound.volume = 1;
    }

    public void TurnDownBackgroundMusic()
    {
        turnDownVolumeMusic = true;
    }

    private void DownBackgroundMusic()
    {
        if (backgroundSound.volume > 0.2f)
        {
            backgroundSound.volume -= Time.deltaTime * 3 / 10;
            return;
        }
        turnDownVolumeMusic = false;
    }
}
