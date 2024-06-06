using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleHint : MonoBehaviour
{
    [SerializeField]
    private GameObject hintBG;

    [SerializeField]
    private List<string> hints = new List<string>();

    [SerializeField]
    private TextMeshProUGUI hintTMP;

    int currentIndex = 0;

    private void Start()
    {
        currentIndex = 0;
        hintTMP.text = hints[currentIndex];
    }

    public void ShowHints()
    {
        currentIndex = 0;
        hintTMP.text = hints[currentIndex];
        hintBG.SetActive(true);
    }

    public void HideHints()
    {
        hintBG.SetActive(false);
    }

    public void NextHint()
    {
        if (currentIndex >= hints.Count - 1)
        {
            currentIndex = 0;
            hintTMP.text = hints[currentIndex];
            return;
        }

        currentIndex++;
        hintTMP.text = hints[currentIndex];
    }

    public void PreviousHint()
    {
        if (currentIndex <= 0)
            return;

        currentIndex--;
        hintTMP.text = hints[currentIndex];
    }
}
