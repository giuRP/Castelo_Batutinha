using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeysInventoryControll : MonoBehaviour
{
    [SerializeField]
    private List<Image> inventoryKeyImages, pickedKeyImages;

    [SerializeField]
    private float sequenceDuration = 1f;

    [SerializeField]
    private Vector3 imageOffset = Vector3.zero;

    private Sequence sequence;

    public UnityEvent OnCollectKey;

    private void OnEnable()
    {
        PickUpKey.OnPickUpKey += PickedKeyAnimation;
    }

    private void OnDisable()
    {
        PickUpKey.OnPickUpKey -= PickedKeyAnimation;
    }

    private void PickedKeyAnimation(int keyIndex)
    {
        //Debug.Log(keyIndex);
        pickedKeyImages[keyIndex].gameObject.SetActive(true);
        PlayUIKeyAnimation(pickedKeyImages[keyIndex], inventoryKeyImages[keyIndex].transform.position);
    }

    private void PlayUIKeyAnimation(Image targetImage, Vector3 endPosition)
    {
        //sequence.Kill();
        DOTween.Kill(sequence);
        sequence = DOTween.Sequence()
            .Append(targetImage.transform.DOMove(endPosition - imageOffset, sequenceDuration));
        sequence.Play();
        OnCollectKey.Invoke();

        StartCoroutine(KillSequence());
    }

    IEnumerator KillSequence()
    {
        yield return new WaitForSeconds(sequenceDuration + .2f);

        GameManager.Instance.CheckWinCondition();
        //sequence.Kill();
        DOTween.Kill(sequence);
    }
}
