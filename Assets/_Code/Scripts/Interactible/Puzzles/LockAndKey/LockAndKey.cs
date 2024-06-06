using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAndKey : Puzzle
{
    public override bool SolvedCheck(ItenDataSO iten)
    {
        if (iten == null)
            return false;

        if (iten == keyIten)
        {
            Debug.Log("Puzzle Resolvido");
            onSolved?.Invoke();
            PuzzleManager.Instance.MarkPuzzlaAsCompleted(this);
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void RaisePuzzleSolved()
    {
        StartCoroutine(RaiseEventDelay());
    }

    IEnumerator RaiseEventDelay()
    {
        yield return new WaitForEndOfFrame();

        onPuzzleSolved.Raise();
    }
}
