using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNoCameraInteraction : Interactible
{
    [SerializeField]
    private Puzzle puzzle;

    private void Awake()
    {
        puzzle = GetComponentInChildren<Puzzle>();
    }

    public override void Execute(Agent agent)
    {
        agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Inventory));
        agent.lockAndKeyPuzzleInteracted = true;
        CheckInteraction(false);
        PuzzleManager.Instance.CurrentPuzzleUpdate(puzzle);
    }
}
