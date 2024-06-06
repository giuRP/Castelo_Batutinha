using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class MovementState : PlayerState
{
    public UnityEvent OnStep;
    public UnityEvent OnStep1;
    public UnityEvent OnStep2;

    public Transform orientation;

    [SerializeField]
    private float stepInterval = 0.2f, timeToStep = 0;

    private float horizontalInput;
    private float verticalInput;

    Vector3 currentVelocity;

    private void Start()
    {
        //orientation = agent.playerCameraHolder.cameraTransform;
        orientation = Camera.main.transform;      
    }

    protected override void EnterState()
    {
        StartCoroutine(WaitForActiveInteractions());

        agent.rb.drag = 5;

        timeToStep = stepInterval - .1f;
    }

    protected override void ExitState()
    {
        StopAllCoroutines();
    }

    public override void StateUpdate()
    {
        CalculateDirection();
        CalculateSpeed(agent.data.maxSpeed);

        if (Mathf.Abs(agent.rb.velocity.x) < 0.01f || Mathf.Abs(agent.rb.velocity.z) < 0.01f)
        {
            agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Idle));
        }

        timeToStep += Time.deltaTime;
        if(timeToStep >= stepInterval)
        {
            OnStep?.Invoke();
            timeToStep = 0;
        }
    }

    public override void StateFixedUpdate()
    {
        CalculateVelocity(agent.data.maxSpeed);
    }

    protected void CalculateVelocity(float speed)
    {
        Vector3 flatVelocity = new Vector3(currentVelocity.x, 0, currentVelocity.z);
        agent.rb.AddForce(flatVelocity * speed * 10f, ForceMode.Force);
    }

    protected void CalculateSpeed(float speed)
    {
        Vector3 flatVelocity = new Vector3(agent.rb.velocity.x, 0, agent.rb.velocity.z);

        if(flatVelocity.magnitude > speed) 
        {
            Vector3 limitedVelocity = flatVelocity.normalized * speed;
            agent.rb.velocity = new Vector3(limitedVelocity.x, 0, limitedVelocity.z);
        }
    }

    protected void CalculateDirection()
    {
        horizontalInput = agent.input.MovementDirection.x;
        verticalInput = agent.input.MovementDirection.z;

        currentVelocity = orientation.right * horizontalInput + orientation.forward * verticalInput;
    }

    public override void HandleCrouch()
    {
        //TestCrouchTransition();
    }

    public void StepSound()
    {
        float val = UnityEngine.Random.Range(0f, 1f);
        if (val <= .5f)
            OnStep1?.Invoke();
        else
            OnStep2?.Invoke();
    }

    IEnumerator WaitForActiveInteractions()
    {
        yield return new WaitForSeconds(2);
        agent.playerFindInteraction.gameObject.SetActive(true);
    }
}
