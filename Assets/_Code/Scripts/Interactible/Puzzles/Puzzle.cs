using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour 
{
    public ItenDataSO keyIten;

    public PuzzleHint puzzleHint;

    [SerializeField]
    private float updateTime = 0.1f;

    [SerializeField]
    protected GameEvent onPuzzleSolved;

    public UnityEvent onSolved;

    public virtual void Awake()
    {
        puzzleHint = GetComponent<PuzzleHint>();
    }

    public virtual bool SolvedCheck(ItenDataSO iten)
    {
        return false;
    }

    public virtual void RaisePuzzleSolved()
    {
        onPuzzleSolved.Raise();
    }

    public virtual IEnumerator MyUpdate()
    {
        yield return new WaitForSeconds(updateTime);

        StartCoroutine(MyUpdate());
    }
}
