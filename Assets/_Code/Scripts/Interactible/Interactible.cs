using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour, ICommand
{
    [SerializeField]
    protected HighlightInteraction highlightInteraction;

    [SerializeField]
    protected InteractionText interactionText;

    public virtual void CheckInteraction(bool val)
    {
        highlightInteraction.ToggleHighlight(val);
        interactionText.EnableMessage(val);
    }

    public virtual void Execute(Agent agent)
    {
        
    }

    public virtual void Undo()
    {
        
    }
}
