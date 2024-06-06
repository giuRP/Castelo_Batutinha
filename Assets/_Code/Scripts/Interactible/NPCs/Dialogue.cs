using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp;

    [SerializeField]
    [TextArea(1, 4)]
    private string[] dialogueLines;

    [SerializeField]
    private float textSpeed;

    [SerializeField]
    private GameEvent OnDialogueFinished;

    private int dialogueIndex;

    [SerializeField]
    private RectTransform dialogueBox;

    private Vector3 startBoxPosition, endBoxPosition;

    private Sequence sequence;


    private void Awake()
    {
        dialogueBox = GetComponent<RectTransform>();

        startBoxPosition = new Vector3(0, -800, 0);
        endBoxPosition = new Vector3(0, -250, 0);

        dialogueBox.localPosition = startBoxPosition;
    }

    public void StartDialogue()
    {
        tmp.text = string.Empty;
        dialogueIndex = 0;

        sequence.Kill();
        sequence = DOTween.Sequence().Append(dialogueBox.DOLocalMove(endBoxPosition, 1f));
        sequence.Play();

        StartCoroutine(TypeLine());
    }

    public void UpdateDialogueLines()
    {
        if(tmp.text == dialogueLines[dialogueIndex])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            tmp.text = dialogueLines[dialogueIndex];
        }
    }

    private void NextLine()
    {
        if(dialogueIndex < dialogueLines.Length - 1)
        {
            dialogueIndex++;
            tmp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            sequence.Kill();
            sequence = DOTween.Sequence().Append(dialogueBox.DOLocalMove(startBoxPosition, 1f));
            sequence.Play();

            OnDialogueFinished.Raise();
        }
    }

    IEnumerator TypeLine()
    {
        //Type each character 1 by 1
        foreach (char c in dialogueLines[dialogueIndex].ToCharArray())
        {
            tmp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
