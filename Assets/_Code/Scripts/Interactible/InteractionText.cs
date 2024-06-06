using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionText : MonoBehaviour
{
    [SerializeField]
    private RectTransform messagePanelUI;

    private Sequence sequence;
    private Vector3 endScale;

    private void Awake()
    {
        endScale = new Vector3(1, 1, 1);
        messagePanelUI.localScale = Vector3.zero;
    }

    public void EnableMessage(bool val)
    {
        if (val)
        {
            sequence.Kill();
            sequence = DOTween.Sequence().Append(messagePanelUI.DOScale(endScale, .4f));
            sequence.Play();
        }
        else
        {
            sequence.Kill();
            sequence = DOTween.Sequence().Append(messagePanelUI.DOScale(Vector3.zero, .2f));
            sequence.Play();
        }
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}
