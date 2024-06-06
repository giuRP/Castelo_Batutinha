using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerFindInteraction : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactionLayers;

    [SerializeField]
    private Transform playerCamTransform;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    private RaycastHit hit1, hit2, hit3;

    public GameObject interactibleObject;

    public void InitializeRaycast(Transform cameraTransform)
    {
        playerCamTransform = cameraTransform;
    }

    public void SearchForInteraction()
    {
        if(!this.gameObject.activeSelf)
            return;

        Debug.DrawRay(transform.position, playerCamTransform.forward * hitRange, Color.red);
        Debug.DrawRay(transform.position, (playerCamTransform.forward + new Vector3(0.05f, -0.05f, 0)) * hitRange, Color.red);
        Debug.DrawRay(transform.position, (playerCamTransform.forward - new Vector3(0.05f, 0.05f, 0)) * hitRange, Color.red);

        if (hit1.collider != null)
        {
            hit1.collider.GetComponent<Interactible>()?.CheckInteraction(false);
            interactibleObject = null;
        }

        if(hit2.collider != null)
        {
            hit2.collider.GetComponent<Interactible>()?.CheckInteraction(false);
            interactibleObject = null;
        }

        if (hit3.collider != null)
        {
            hit3.collider.GetComponent<Interactible>()?.CheckInteraction(false);
            interactibleObject = null;
        }

        if (Physics.Raycast(transform.position, playerCamTransform.forward, out hit1, hitRange, interactionLayers))
        {
            hit1.collider.GetComponent<Interactible>()?.CheckInteraction(true);
            interactibleObject = hit1.collider?.gameObject;
        }

        if (Physics.Raycast(transform.position, (playerCamTransform.forward + new Vector3(0.05f, -0.05f, 0)), 
            out hit2, hitRange, interactionLayers))
        {
            hit2.collider.GetComponent<Interactible>()?.CheckInteraction(true);
            interactibleObject = hit1.collider?.gameObject;
        }

        if (Physics.Raycast(transform.position, (playerCamTransform.forward - new Vector3(0.05f, 0.05f, 0)), 
            out hit3, hitRange, interactionLayers))
        {
            hit3.collider.GetComponent<Interactible>()?.CheckInteraction(true);
            interactibleObject = hit1.collider?.gameObject;
        }
    }
}
