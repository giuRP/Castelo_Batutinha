using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRegister : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            PuzzleManager.Instance.puzzleSets.Add(transform.GetChild(i).GetComponent<Interactible>()?
                .GetComponentInChildren<Puzzle>());
        }

        PuzzleManager.Instance.CurrentPuzzleUpdateInOrder();
    }
}
