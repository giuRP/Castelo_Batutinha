using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    public CinemachineVirtualCamera playerVCam;
    public CinemachineVirtualCamera interactionVCam;
    public CinemachineVirtualCamera doorVCam;
    public CinemachineVirtualCamera specificVCam;

    [SerializeField]
    private CinemachineVirtualCamera currentCam;

    private void Start()
    {
        playerVCam.Priority = 30;
        interactionVCam.Priority = 20;
        doorVCam.Priority = 10;
        specificVCam.Priority = 1;

        SwitchToPlayerCamera();
    }

    public void SwitchToPlayerCamera()
    {
        specificVCam.gameObject.SetActive(false);

        playerVCam.gameObject.SetActive(true);

        currentCam = playerVCam;
        interactionVCam.Follow = null;
        doorVCam.Follow = null;
    }

    public void SwitchToInteractionCamera(Transform cameraHolder)
    {
        playerVCam.gameObject.SetActive(false);

        interactionVCam.gameObject.SetActive(true);

        currentCam = interactionVCam;

        interactionVCam.Follow = cameraHolder;
        interactionVCam.transform.rotation = cameraHolder.transform.rotation;
    }

    public void SwitchToDoorCamera(Transform cameraHolder)
    {
        playerVCam.gameObject.SetActive(false);
        interactionVCam.gameObject.SetActive(false);

        doorVCam.gameObject.SetActive(true);

        currentCam = doorVCam;

        doorVCam.Follow = cameraHolder;
        doorVCam.transform.rotation = cameraHolder.transform.rotation;
    }

    public void SwitchToSpecificCamera(Transform cameraHolder)
    {
        playerVCam.gameObject.SetActive(false);
        interactionVCam.gameObject.SetActive(false);
        doorVCam.gameObject.SetActive(false);

        specificVCam.gameObject.SetActive(true);

        currentCam = specificVCam;

        specificVCam.Follow = cameraHolder;
        specificVCam.transform.rotation = cameraHolder.transform.rotation;
    }
}
