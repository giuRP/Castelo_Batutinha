using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSystem : MonoBehaviour
{
    [SerializeField]
    private Transform cameraHolder;

    [SerializeField]
    private BoxCollider doorCollider;

    [SerializeField]
    private float soundClipDuration;

    [SerializeField]
    private Rigidbody rb;
    private float openSpeed;
    private float finalPosition;

    [Header("Events")]
    public GameEvent onDoorOpened;

    private void Start()
    {
        cameraHolder = transform.GetChild(0);
        doorCollider = GetComponentInChildren<BoxCollider>();
        rb = GetComponentInChildren<Rigidbody>();

        openSpeed = doorCollider.size.z / soundClipDuration;

        finalPosition = -doorCollider.gameObject.transform.position.y * 2;
    }

    public void OpenDoor()
    {
        StartCoroutine(DoorOpening());
    }

    public void SwitchCamera()
    {
        CameraManager.Instance.SwitchToDoorCamera(cameraHolder);
    }

    private IEnumerator DoorOpening()
    {
        yield return new WaitForEndOfFrame();

        if(doorCollider.gameObject.transform.position.y <= finalPosition)
        {
            rb.velocity = Vector3.zero;
            onDoorOpened.Raise();
            StopCoroutine(DoorOpening());
        }
        else
        {
            rb.velocity = new Vector3(0, -openSpeed, 0);
            StartCoroutine(DoorOpening());
        }
    }
}
