using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : Interactible
{
    [SerializeField]
    private int keyIndex;

    [SerializeField]
    private float animDuration = 1f;

    private Sequence moveSequence;
    private Sequence scaleSequence;

    public static event Action<int> OnPickUpKey;

    public override void Execute(Agent agent)
    {
        //Tocar som de item coletado

        PickUpAnimation(agent.transform.position, Vector3.zero);
    }

    private void PickUpAnimation(Vector3 endPosition, Vector3 endScale)
    {
        moveSequence.Kill();
        scaleSequence.Kill();

        moveSequence = DOTween.Sequence()
            .Append(gameObject.transform.DOMove(endPosition, animDuration));
        scaleSequence = DOTween.Sequence()
            .Append(gameObject.transform.DOScale(endScale, animDuration));

        moveSequence.Play();
        scaleSequence.Play();

        StartCoroutine(KillSequence());
    }

    IEnumerator KillSequence()
    {
        yield return new WaitForSeconds(animDuration + .5f);

        OnPickUpKey.Invoke(keyIndex);

        moveSequence.Kill();
        scaleSequence.Kill();

        Destroy(gameObject);
    }
}
