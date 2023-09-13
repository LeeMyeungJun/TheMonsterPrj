using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioClip audioClip2;

    void Start()
    {
        SoundManager.Instance.BgmPlay(audioClip);
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            SoundManager.Instance.SfxPlay(audioClip2);
            Debug.Log("SoundManager.Instance.SfxPlay(audioClip2)");

        }

    }
}
