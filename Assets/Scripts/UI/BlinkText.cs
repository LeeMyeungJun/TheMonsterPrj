using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class BlinkText : MonoBehaviour
{
    public LoopType loopType;
    public TextMeshProUGUI text;
    void Start()
    {
        text.DOFade(0.3f, 1).SetLoops(-1, loopType);
    }

}
