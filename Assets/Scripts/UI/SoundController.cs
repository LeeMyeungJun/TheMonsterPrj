using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    Slider bgmSlider;
    Slider sfxSlider;
    public AudioSource bgmAudio;
    public AudioSource sfxAudio;

    private void Awake()
    {
        bgmSlider = this.transform.Find("sldr_Bgm").GetComponent<Slider>();
        sfxSlider = this.transform.Find("sldr_Sfx").GetComponent<Slider>();

        bgmAudio = SoundManager.Instance.bgmAudio;
        sfxAudio = SoundManager.Instance.sfxAudio;
    }

    void Start()
    {
        bgmSlider.onValueChanged.AddListener(OnBgmVolChanged);
        sfxSlider.onValueChanged.AddListener(OnSfxVolChanged);
    }

    void OnBgmVolChanged(float value)
    {
        bgmAudio.volume = value;
    } 
    void OnSfxVolChanged(float value)
    {
        sfxAudio.volume = value;
    }

    
}
