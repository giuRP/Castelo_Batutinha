using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    protected override void EnterState()
    {
        StartCoroutine(WaitForActiveInteractions());
        CameraManager.Instance.SwitchToPlayerCamera();
    }

    protected override void ExitState()
    {
        StopAllCoroutines();
    }

    public override void HandleMovement(Vector3 input)
    {
        if(Mathf.Abs(input.x) > 0 || Mathf.Abs(input.z) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Movement));
        }
    }

    IEnumerator WaitForActiveInteractions()
    {
        yield return new WaitForSeconds(2);
        agent.playerFindInteraction.gameObject.SetActive(true);
    }
}
