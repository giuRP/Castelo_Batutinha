using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    [Header("State Debbuging: ")]
    public string stateName = "";

    public PlayerState currentState = null, previousState = null;

    [Header("Player Componets: ")]
    public AgentDataSO data;
    public PlayerStateFactory stateFactory;
    public IAgentInput input;
    public Rigidbody rb;
    public PlayerFindInteraction playerFindInteraction;
    public GameObject playerCameraHolder;
    public AgentInventory inventory;
    [HideInInspector]
    public Dialogue currentDialogue;

    [Header("Player UI Settings: ")]
    public NewItenMessageUI newItenMessageUI;

    [Header("Player Parameters: ")]
    public bool isCrouch;
    public bool lockAndKeyPuzzleInteracted;

    private void Awake()
    {
        stateFactory = GetComponentInChildren<PlayerStateFactory>();

        stateFactory.InitializeStates(this);

        input = GetComponent<IAgentInput>();
        rb = GetComponent<Rigidbody>();
        playerFindInteraction = GetComponentInChildren<PlayerFindInteraction>();
        playerCameraHolder = transform.GetChild(0).gameObject;
        inventory = GetComponentInChildren<AgentInventory>();

        newItenMessageUI = GetComponentInChildren<NewItenMessageUI>();

        isCrouch = false;
        lockAndKeyPuzzleInteracted = false;
    }

    private void OnEnable()
    {
        GameManager.Instance.OnPickUpAllKeys += BlockInput;
        PlayAudioLog.OnFinishCutScene += UnblockInput;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPickUpAllKeys -= BlockInput;
        PlayAudioLog.OnFinishCutScene -= UnblockInput;
    }

    private void Start()
    {
        InitializeAgent();
        playerFindInteraction.InitializeRaycast(Camera.main.transform);
    }

    private void Update()
    {
        currentState.StateUpdate();
        playerFindInteraction.SearchForInteraction();
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }

    private void LateUpdate()
    {
        currentState.StateLateUpdate();
    }

    private void InitializeAgent()
    {
        TransitionToState(stateFactory.GetState(PlayerStateType.Idle));
    }

    public void TransitionToState(PlayerState goalState)
    {
        if (goalState == null)
            return;

        if (currentState != null)
            currentState.Exit();

        previousState = currentState;
        currentState = goalState;
        currentState.Enter();

        DisplayState();
    }

    private void DisplayState()
    {
        if (previousState == null || previousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }

    public void InteractWithObject()
    {
        if (playerFindInteraction.interactibleObject == null)
            return;
        
        playerFindInteraction.interactibleObject?.GetComponent<ICommand>()?.Execute(this);
    }

    public void InteractWithNPC(Dialogue dialogue)
    {
        currentDialogue = dialogue;
    }

    public void ResetCursorVisibility()
    {
        Cursor.visible = false;
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }

    private void BlockInput()
    {
        input.IsInputBlocked = true;
        //Debug.Log(input.IsInputBlocked);
    }

    private void UnblockInput()
    {
        input.IsInputBlocked = false;
        //Debug.Log(input.IsInputBlocked);
    }
}
