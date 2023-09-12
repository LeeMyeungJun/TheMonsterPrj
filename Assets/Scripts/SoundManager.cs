using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public enum Sound
{
    Bgm,
    Effect,
    MaxCount,  // 아무것도 아님. 그냥 Sound enum의 개수 세기 위해 추가. (0, 1, '2' 이렇게 2개) 
}
public class SoundManager : MonoSingleton<SoundManager>
{
    public AudioSource bgmAudio;
    public AudioSource sfxAudio;

    void Start()
    {
        bgmAudio = GetComponent<AudioSource>();
        sfxAudio = GetComponent<AudioSource>();
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
