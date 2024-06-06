using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public UnityEvent OnEnter, OnExit;

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public virtual void Enter()
    {
        //Subscribe Delegates & Actions

        OnEnter?.Invoke();

        EnterState();
    }

    public virtual void Exit()
    {
        //Unscribe Delegates & Actions

        OnExit?.Invoke();

        ExitState();
    }

    protected virtual void EnterState()
    {
    }

    protected virtual void ExitState()
    {
    }

    public virtual void StateUpdate()
    {
    }

    public virtual void StateFixedUpdate()
    {
    }

    public virtual void StateLateUpdate()
    {
    }
}
