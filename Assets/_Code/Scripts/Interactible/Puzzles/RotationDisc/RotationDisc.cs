using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDisc : Puzzle
{
    [SerializeField]
    private List<RotationPiece> pieces;

    public List<RotationPiece> solvedPieces;

    public Vector3 rotationAxis = Vector3.zero;

    public int minValue, maxValue;

    public float step;

    public override void Awake()
    {
        base.Awake();
        keyIten = null;
        pieces = new List<RotationPiece>();
        solvedPieces = new List<RotationPiece>();

        step = 360 / maxValue;

        for (int i = 0; i < transform.childCount; i++)
        {
            pieces.Add(transform.GetChild(i).GetComponent<RotationPiece>());
        }
    }

    public override bool SolvedCheck(ItenDataSO iten)
    {
        if (solvedPieces.Count >= pieces.Count)
        {
            //Puzzle resolvido
            Debug.Log("Puzzle Resolvido");
            RaisePuzzleSolved();
            onSolved?.Invoke();
            PuzzleManager.Instance.MarkPuzzlaAsCompleted(this);
            StopCoroutine(MyUpdate());
        }

        return solvedPieces.Count >= pieces.Count;
    }

    public override IEnumerator MyUpdate()
    {
        return base.MyUpdate();
    }
}
