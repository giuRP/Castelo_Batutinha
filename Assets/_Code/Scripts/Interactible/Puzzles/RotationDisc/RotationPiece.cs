using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotationPiece : Interactible
{
    [SerializeField]
    private RotationDisc rotationDisc;

    [SerializeField]
    private int solutionValue, currentValue = 0;

    [SerializeField]
    private int rotationDirectionFactor = 1;

    public UnityEvent OnPieceClicked;

    private void Start()
    {
        interactionText = null;

        rotationDisc = GetComponentInParent<RotationDisc>();

        currentValue = Random.Range(rotationDisc.minValue, rotationDisc.maxValue);

        if (currentValue == solutionValue)
            currentValue++;

        if (currentValue == rotationDisc.maxValue)
            currentValue = 0;

        transform.Rotate(rotationDisc.rotationAxis * rotationDisc.step * currentValue * rotationDirectionFactor, Space.Self);
    }

    public override void CheckInteraction(bool val)
    {
        highlightInteraction.ToggleHighlight(val);
    }

    public override void Execute(Agent agent)
    {
        currentValue++;

        if (currentValue == rotationDisc.maxValue)
            currentValue = 0;

        transform.Rotate(rotationDisc.rotationAxis * rotationDisc.step * rotationDirectionFactor, Space.Self);
        OnPieceClicked?.Invoke();

        CheckSolutionValue();

        rotationDisc.SolvedCheck(null);
    }

    public override void Undo()
    {
        return;
    }

    public void CheckSolutionValue()
    {
        if(currentValue == solutionValue)
        {
            rotationDisc.solvedPieces.Add(this);
        }
        else
        {
            rotationDisc.solvedPieces.Remove(this);
        }
    }

    //public void ClockwiseRotation()
    //{
    //    if (currentValue == maxValue)
    //        currentValue = 0;

    //    currentValue++;
    //    transform.Rotate(rotationAxis * step, Space.Self);

    //    //Checar se ta na posição certa
    //}

    //public void CounterClockwiseRotation()
    //{
    //    if (currentValue == maxValue)
    //        currentValue = 0;

    //    currentValue--;
    //    transform.Rotate(rotationAxis * -step, Space.Self);

    //    //Checar se ta na posição certa
    //}
}
