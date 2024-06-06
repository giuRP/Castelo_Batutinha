using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintState : PlayerState
{
    protected override void EnterState()
    {
        Time.timeScale = 0;
        Cursor.visible = true;

        if(PuzzleManager.Instance.puzzleSets.Count <= 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Idle));
            return;
        }

        //Display current puzzle-set hints
        PuzzleManager.Instance.currentPuzzle.puzzleHint.ShowHints();
        agent.playerFindInteraction.gameObject.SetActive(false);
    }

    protected override void ExitState()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        agent.playerFindInteraction.gameObject.SetActive(true);
        //Start Hint Abillity Cool Down
    }

    public override void HandleBackAction()
    {
        PuzzleManager.Instance.currentPuzzle.puzzleHint.HideHints();
        agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Idle));
    }

    public override void HandleHint()
    {
        //Do nothing;
    }

    public override void HandleInteraction()
    {
        //Do Nothing;
    }

    public override void HandleInventoryOpen()
    {
        //Do Nothing;
    }
}
