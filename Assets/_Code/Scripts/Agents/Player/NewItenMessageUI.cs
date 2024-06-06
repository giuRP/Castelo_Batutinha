using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewItenMessageUI : MonoBehaviour
{
    [SerializeField]
    private GameObject itenImage;

    [SerializeField]
    private TextMeshProUGUI itenTMP;

    private Sequence sequence;
    private Vector3 endScale;
    private RectTransform panelTransform;

    private void Awake()
    {
        endScale = Vector3.one;
        panelTransform = GetComponent<RectTransform>();
        panelTransform.localScale = Vector3.zero;
    }

    public void GetItenData(ItenDataSO itenData)
    {
        if(itenImage.GetComponent<Image>() != null)
        {
            itenImage.GetComponent<Image>().sprite = itenData.itenImage;
            //itenImage.GetComponent<Image>().SetNativeSize();
        }

        itenTMP.text = itenData.itenName;
    }

    public void EnableMessage(bool val)
    {
        if (val)
        {
            sequence.Kill();
            sequence = DOTween.Sequence().Append(panelTransform.DOScale(endScale, .001f));
            sequence.Play();
        }
        else
        {
            sequence.Kill();
            sequence = DOTween.Sequence().Append(panelTransform.DOScale(Vector3.zero, .001f));
            sequence.Play();
        }
    }
}
