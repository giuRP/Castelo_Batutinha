using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/Data")]
public class AgentDataSO : ScriptableObject
{
    [Header("Movement Data")]
    [Space]
    public float maxSpeed = 6;
    public float climbSpeed = 3;
    public float crouchSpeed = 2;
}
