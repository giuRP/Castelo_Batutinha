using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    public Vector3 MovementDirection {  get; private set; }
    public bool IsInputBlocked { get; set; }

    public event Action<Vector3> OnMovement;
    public event Action OnCrouch;
    public event Action OnInventoryOpen;
    public event Action OnInteract;
    public event Action OnBackAction;
    public event Action OnAskForAHint;

    public KeyCode crouchKey, inventoryKey, interactKey, backActionKey, hintKey, menuKey;

    public UnityEvent OnMenuKeyPressed;

    private void Update()
    {
        if(Time.timeScale > 0 && IsInputBlocked == false)
        {
            GetMovementInput();
            GetCrouchInput();
            GetHintInput();
            GetInventoryInput();
            GetInteractInput();
        }

        if(IsInputBlocked == false)
        {
            GetBackActionInput();
            GetMenuInput();
        }
    }

    private void GetMovementInput()
    {
        MovementDirection = GetMovementDirection();
        OnMovement?.Invoke(MovementDirection);
    }

    protected Vector3 GetMovementDirection()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void GetCrouchInput()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            OnCrouch?.Invoke();
        }
    }

    private void GetInventoryInput()
    {
        if(Input.GetKeyDown(inventoryKey))
        {
            OnInventoryOpen?.Invoke();
        }
    }

    private void GetInteractInput()
    {
        if(Input.GetKeyDown(interactKey))
        {
            OnInteract?.Invoke();
        }
    }

    private void GetBackActionInput()
    {
        if (Input.GetKeyDown(backActionKey))
        {
            OnBackAction?.Invoke();
        }
    }

    private void GetHintInput()
    {
        if(Input.GetKeyDown(hintKey))
        {
            OnAskForAHint?.Invoke();
        }
    }

    private void GetMenuInput()
    {
        if(Input.GetKeyDown(menuKey))
        {
            OnMenuKeyPressed?.Invoke();
        }
    }
}
