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
public class SoundManager : MonoSingle<SoundManager>
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

    /*public void Play(string path, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }

    AudioClip GetOrAddAudioClip(string path, Sound type = Sound.Effect)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}"; // 📂Sound 폴더 안에 저장될 수 있도록

        AudioClip audioClip = null;

        if (type == Define.Sound.Bgm) // BGM 배경음악 클립 붙이기
        {
            audioClip = Managers.Resource.Load<AudioClip>(path);
        }
        else // Effect 효과음 클립 붙이기
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    }*/
}
