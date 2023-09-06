using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;
    public static CameraManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CameraManager>();
            }
            return instance;
        }
    }

    Vector3 originPos = Vector3.zero;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnCameraShake(0.5f, 0.2f);
        }
    }
    public void OnCameraShake(float _duration,float _magnitude) // 0.2f 가 적당한듯 ... 
    {
        originPos = this.transform.localPosition;
        StartCoroutine(ShakeCamera(_duration, _magnitude));
    }

    IEnumerator ShakeCamera(float _duration, float _magnitude)
    {
        float timer = 0;

        while (timer <= _duration) 
        {
            transform.localPosition = Random.insideUnitSphere * _magnitude + originPos;

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originPos;
    }
}
