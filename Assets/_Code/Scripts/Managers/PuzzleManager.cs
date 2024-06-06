using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : Singleton<PuzzleManager>
{
    public List<Puzzle> puzzleSets = new List<Puzzle>();

    public Puzzle currentPuzzle;

    public GameEvent onAllFloorPuzzlesCompleted;

    [SerializeField]
    private float timeToRestoreHintOrder = 3f;

    public void CurrentPuzzleUpdateInOrder()
    {
        if (puzzleSets.Count <= 0)
            return;
        currentPuzzle = puzzleSets[0];
    }

    public void CurrentPuzzleUpdate(Puzzle puzzle)
    {
        if(puzzleSets.Contains(puzzle))
        {
            currentPuzzle = puzzle;
        }
        else
        {
            currentPuzzle = puzzleSets[0];
        }
        StartCoroutine(RestoreToOriginalPuzzleOrder());
    }

    public void MarkPuzzlaAsCompleted(Puzzle puzzle)
    {
        if(puzzleSets.Contains(puzzle))
        {
            Debug.Log($"{puzzle.name} removido");
            puzzleSets.Remove(puzzle);
        }

        if(puzzleSets.Count <= 0)
        {
            Debug.Log("Floor Completed");
            onAllFloorPuzzlesCompleted.Raise();
            currentPuzzle = null;
            return;
        }

        CurrentPuzzleUpdateInOrder();
    }

    IEnumerator RestoreToOriginalPuzzleOrder()
    {
        yield return new WaitForSeconds(timeToRestoreHintOrder);

        CurrentPuzzleUpdateInOrder();
    }
}
