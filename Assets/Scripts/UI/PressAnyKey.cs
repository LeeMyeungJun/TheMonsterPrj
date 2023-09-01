using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using DG.Tweening;

public class PressAnyKey : MonoBehaviour
{
    public List<Image> PadeInTarget;

    public Vector2 EndSize;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            Debug.Log("PRESS ANY KEY");
            
            foreach(Image img in PadeInTarget)
            {
                img.DOFade(1.0f, 0.5f);

            }

            this.gameObject.SetActive(false);
        }
    }
}
