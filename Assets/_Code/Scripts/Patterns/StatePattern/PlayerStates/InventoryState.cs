using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryState : PlayerState
{
    protected override void EnterState()
    {
        Time.timeScale = 0;
        agent.playerFindInteraction.gameObject.SetActive(false);
        Cursor.visible = true;
    }

    protected override void ExitState()
    {
        Time.timeScale = 1;
        agent.playerFindInteraction.gameObject.SetActive(true);
        agent.lockAndKeyPuzzleInteracted = false;
        agent.inventory.ReorganizeInventory();
        agent.inventory.ResetAmpViewItemImage();
        Cursor.visible = false;
    }

    //public override void HandleMovement(Vector3 obj)
    //{
    //    //Do nothing
    //}

    public override void HandleInteraction()
    {
        //Do nothing
    }

    public override void HandleHint()
    {
        //Do nothing
    }

    public override void HandleInventoryOpen()
    {
        //Do nothing
    }

    public override void HandleBackAction()
    {
        agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Idle));
    }
}
