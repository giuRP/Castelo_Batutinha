using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory : MonoBehaviour
{
    [SerializeField]
    private PlayerState Idle, Movement, Climb, Crouch, Inventory, Dialogue, SolvingPuzzle, AskForAHint;

    public PlayerState GetState(PlayerStateType stateType) => stateType switch
    {
        PlayerStateType.Idle => Idle,
        PlayerStateType.Movement => Movement,
        PlayerStateType.Climb => Climb,
        PlayerStateType.Crouch => Crouch,
        PlayerStateType.Inventory => Inventory,
        PlayerStateType.Dialogue => Dialogue,
        PlayerStateType.SolvingPuzzle => SolvingPuzzle,
        PlayerStateType.AskForAHint => AskForAHint,
        _ => throw new System.Exception("State not defined " + stateType.ToString())
    };

    public void InitializeStates(Agent agent)
    {
        PlayerState[] states = GetComponents<PlayerState>();
        foreach (var state in states)
        {
            state.InitializeState(agent);
        }
    }
}

public enum PlayerStateType
{
    Idle,
    Movement,
    Climb,
    Crouch,
    Inventory,
    Dialogue,
    SolvingPuzzle,
    AskForAHint
}
