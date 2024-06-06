using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvingPuzzleState : PlayerState
{
    [SerializeField]
    private LayerMask interactionLayers;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    [SerializeField]
    private GameObject interectibleObject;

    Ray ray;
    RaycastHit hit;

    protected override void EnterState()
    {
        Cursor.visible = true;
        agent.playerFindInteraction.gameObject.SetActive(false);
    }

    protected override void ExitState()
    {
        Cursor.visible = false;
        agent.playerFindInteraction.gameObject.SetActive(true);
    }

    public override void StateUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (hit.collider != null)
        {
            hit.collider.GetComponent<Interactible>()?.CheckInteraction(false);
            interectibleObject = null;
        }

        if (Physics.Raycast(ray, out hit, hitRange, interactionLayers))
        {
            hit.collider.GetComponent<Interactible>()?.CheckInteraction(true);
            interectibleObject = hit.collider.gameObject;
        }
    }

    public override void HandleInteraction()
    {
        if (interectibleObject == null)
            return;

        if (interectibleObject.GetComponent<ICommand>() == null)
            return;

        interectibleObject.GetComponent<ICommand>().Execute(agent);
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
        agent.TransitionToState(agent.previousState); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}
