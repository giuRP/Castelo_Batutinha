using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayAudioLog : MonoBehaviour
{
    [SerializeField]
    private Transform vCamHolder;

    [SerializeField]
    private float audioDuration = 0f;

    public UnityEvent OnPlayLog;

    public static event Action OnAudioLogEnds;
    public static event Action OnFinishCutScene;

    private void OnEnable()
    {
        GameManager.Instance.OnPickUpAllKeys += PlayLog;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPickUpAllKeys -= PlayLog;
    }

    private void PlayLog()
    {
        CameraManager.Instance.SwitchToSpecificCamera(vCamHolder);
        OnPlayLog?.Invoke();
        StartCoroutine(CallWhenAudioEnds());
    }

    IEnumerator CallWhenAudioEnds()
    {
        yield return new WaitForSeconds(audioDuration);
        OnAudioLogEnds?.Invoke();
        yield return new WaitForSeconds(3f);
        OnFinishCutScene?.Invoke();
    }
}
