using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : PlayerState
{
    protected override void EnterState()
    {
        agent.playerFindInteraction.gameObject.SetActive(false);
    }

    protected override void ExitState()
    {
        agent.currentDialogue = null;
    }

    public override void HandleInteraction()
    {
        agent.currentDialogue.UpdateDialogueLines();
    }

    public override void HandleHint()
    {
        //Do nothing;
    }

    public override void HandleInventoryOpen()
    {
        //Do Nothing;
    }
}
