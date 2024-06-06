using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class MainDoor : Interactible
{
    [SerializeField]
    private Transform vCamHolder;

    [SerializeField]
    private CanvasGroup fadeImage;

    [SerializeField]
    private float fadeDuration = 1.0f;

    public UnityEvent OnFailInteract;
    public UnityEvent OnUnlockDoor;

    private bool isUnlocked = false;

    private Sequence sequence;

    private void OnEnable()
    {
        PlayAudioLog.OnAudioLogEnds += UnlockDoor;
    }

    private void OnDisable()
    {
        PlayAudioLog.OnAudioLogEnds -= UnlockDoor;
    }

    public override void Execute(Agent agent)
    {
        if (isUnlocked)
        {
            PlayFade();
            Debug.Log("Acabou");
        }
        else
        {
            OnFailInteract?.Invoke();
        }
    }

    private void PlayFade()
    {
        DOTween.Kill(sequence);

        fadeImage.alpha = 0;

        sequence = DOTween.Sequence()
            .Append(fadeImage.DOFade(1, fadeDuration));

        sequence.Play();

        StartCoroutine(WhenFadeEnds());
    }

    private void UnlockDoor()
    {
        CameraManager.Instance.SwitchToSpecificCamera(vCamHolder);
        
        StartCoroutine(PlayAsyncAudio());

        StartCoroutine(ReturnToPlayer());
    }

    IEnumerator WhenFadeEnds()
    {
        yield return new WaitForSeconds(fadeDuration + .2f);
        DOTween.Kill(sequence);
        ScenesManager.Instance.LoadNextScene();
    }

    IEnumerator PlayAsyncAudio()
    {
        yield return new WaitForSeconds(1);
        OnUnlockDoor?.Invoke();
    }

    IEnumerator ReturnToPlayer()
    {
        isUnlocked = true;
        yield return new WaitForSeconds(3);
        CameraManager.Instance.SwitchToPlayerCamera();
    }
}
