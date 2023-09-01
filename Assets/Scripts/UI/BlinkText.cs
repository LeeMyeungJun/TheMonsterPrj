using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BlinkText : MonoBehaviour
{
    public LoopType loopType;
    public TextMeshProUGUI text;
    void Start()
    {
        text.DOFade(0.7f, 1).SetLoops(-1, loopType);
    }

}
