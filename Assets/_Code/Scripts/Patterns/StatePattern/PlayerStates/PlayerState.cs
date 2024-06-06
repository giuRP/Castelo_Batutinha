using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    public override void Enter()
    {
        this.agent.input.OnMovement += HandleMovement;
        this.agent.input.OnCrouch += HandleCrouch;
        this.agent.input.OnInventoryOpen += HandleInventoryOpen;
        this.agent.input.OnInteract += HandleInteraction;
        this.agent.input.OnBackAction += HandleBackAction;
        this.agent.input.OnAskForAHint += HandleHint;

        base.Enter();
    }

    public override void Exit()
    {
        this.agent.input.OnMovement -= HandleMovement;
        this.agent.input.OnCrouch -= HandleCrouch;
        this.agent.input.OnInventoryOpen -= HandleInventoryOpen;
        this.agent.input.OnInteract -= HandleInteraction;
        this.agent.input.OnBackAction -= HandleBackAction;
        this.agent.input.OnAskForAHint -= HandleHint;

        base.Exit();
    }

    #region HANDLERS

    public virtual void HandleMovement(Vector3 obj) { }

    public virtual void HandleCrouch() { }

    public virtual void HandleInventoryOpen() 
    {
        agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Inventory));
    }

    public virtual void HandleInteraction()
    {
        //Se for um Item => Pegar item + Add no inventario;
        //Se for um Botao => command.execute();
        //Se for um Puzzle => transition to state: SolvingPuzzle;
        //Se for um dialogo => transition to state: Dialogue;

        agent.InteractWithObject();
    }

    public virtual void HandleBackAction()
    {
        //Só pode fazer alguma ação se for sobrescrito por algum estado que realmente tenha a opção de voltar a ação.
        //Por exemplo: inventário, puzzle e dialogo;

        //agent.TransitionToState(agent.previousState);
    }

    public virtual void HandleHint()
    {
        agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.AskForAHint));
    }

    #endregion

    #region TEST TRANSITIONS

    protected virtual void TestCrouchTransition()
    {
        //if (agent.isCrouch == true)
        //{
        //    agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Movement));
        //}
        //else
        //{
        //    agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Crouch));
        //}
    }

    #endregion
}
