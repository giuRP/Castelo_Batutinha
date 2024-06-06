using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteraction : Interactible
{
    [SerializeField]
    private TextMeshProUGUI tmpName;

    [SerializeField]
    private Dialogue dialogue;

    private void Awake()
    {
        if (tmpName != null)
            tmpName.text = gameObject.name;
    }

    public override void Execute(Agent agent)
    {
        agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Dialogue));
        agent.InteractWithNPC(dialogue);
        CheckInteraction(false);

        dialogue.StartDialogue();
    }
}
