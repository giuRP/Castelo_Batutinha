using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : MovementState
{
    [SerializeField]
    private float currentCamHeight, minCamHeight = 0.1f, maxCamHeight;

    private void Start()
    {
        orientation = Camera.main.transform;

        maxCamHeight = agent.playerCameraHolder.transform.position.y;
        currentCamHeight = maxCamHeight;
    }

    protected override void EnterState()
    {
        StartCoroutine(WaitForActiveInteractions());

        agent.isCrouch = true;
        CameraManager.Instance.SwitchToPlayerCamera();
        agent.rb.drag = 5;
    }

    protected override void ExitState()
    {
        StartCoroutine(MakeAgentStand());
        StopCoroutine(WaitForActiveInteractions());
    }

    public override void StateUpdate()
    {
        MakeAgentCrouch();

        CalculateDirection();
        CalculateSpeed(agent.data.crouchSpeed);
    }

    public override void StateFixedUpdate()
    {
        CalculateVelocity(agent.data.crouchSpeed);
    }

    private void MakeAgentCrouch()
    {
        if (agent.isCrouch == false)
            return;

        float crouchRate = 4f;

        currentCamHeight -= crouchRate * Time.deltaTime;

        currentCamHeight = Mathf.Clamp(currentCamHeight, minCamHeight, maxCamHeight);

        agent.playerCameraHolder.transform.position = new Vector3(agent.playerCameraHolder.transform.position.x, 
            currentCamHeight, agent.playerCameraHolder.transform.position.z);
    }

    IEnumerator MakeAgentStand()
    {
        Debug.Log("MakeAgentStand");
        Debug.Log(currentCamHeight);
        if (currentCamHeight < maxCamHeight)
        {
            currentCamHeight += 0.1f;

            currentCamHeight = Mathf.Clamp(currentCamHeight, minCamHeight, maxCamHeight);

            agent.playerCameraHolder.transform.position = new Vector3(agent.playerCameraHolder.transform.position.x, 
                currentCamHeight, agent.playerCameraHolder.transform.position.z);
        }
        else
        {
            agent.isCrouch = false;

            currentCamHeight = maxCamHeight;

            agent.playerCameraHolder.transform.position = new Vector3(agent.playerCameraHolder.transform.position.x, 
                maxCamHeight, agent.playerCameraHolder.transform.position.z);

            StopAllCoroutines();
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(MakeAgentStand());
    }

    IEnumerator WaitForActiveInteractions()
    {
        yield return new WaitForSeconds(2);
        agent.playerFindInteraction.gameObject.SetActive(true);
    }
}
