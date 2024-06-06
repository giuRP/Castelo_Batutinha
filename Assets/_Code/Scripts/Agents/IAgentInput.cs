using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgentInput 
{
    Vector3 MovementDirection { get; }
    bool IsInputBlocked { get; set; }

    event Action<Vector3> OnMovement;
    event Action OnCrouch;
    event Action OnInventoryOpen;
    event Action OnInteract;
    event Action OnBackAction;
    event Action OnAskForAHint;
}
