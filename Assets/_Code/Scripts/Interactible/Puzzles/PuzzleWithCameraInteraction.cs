using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleWithCameraInteraction : Interactible
{
    [SerializeField]
    private Transform cameraHolder;

    [SerializeField]
    private Puzzle puzzle;

    private void Awake()
    {
        cameraHolder = transform.GetChild(0);
        puzzle = GetComponentInChildren<Puzzle>();
    }

    public override void Execute(Agent agent)
    {
        agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.SolvingPuzzle));
        CheckInteraction(false);
        CameraManager.Instance.SwitchToInteractionCamera(cameraHolder);
        PuzzleManager.Instance.CurrentPuzzleUpdate(puzzle);
    }

    public override void Undo()
    {
        return;
    }
}
