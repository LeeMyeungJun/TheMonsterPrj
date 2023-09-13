using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource[] audioSources;
    public AudioSource bgmAudio;
    public AudioSource sfxAudio;
    void Start()
    {
        audioSources = this.gameObject.GetComponents<AudioSource>();
        bgmAudio = audioSources[0];
        sfxAudio = audioSources[1];
    }

    public void BgmPlay(AudioClip audioClip, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (bgmAudio.isPlaying)
            bgmAudio.Stop();

        bgmAudio.pitch = pitch;
        bgmAudio.clip = audioClip;
        bgmAudio.Play();
    }
    

    public void SfxPlay(AudioClip audioClip, float pitch = 1.0f)
    {
        sfxAudio.pitch = pitch;
        sfxAudio.PlayOneShot(audioClip);
    }
}
