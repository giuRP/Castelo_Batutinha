using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerOptionsControll : MonoBehaviour
{
    [SerializeField]
    private Slider senseSlider;

    [SerializeField]
    private Slider volumeSlider;

    private CinemachinePOV vCamPOVComponent;
    private AudioMixer audioMixer;

    private void Start()
    {
        vCamPOVComponent = CameraManager.Instance.playerVCam.GetCinemachineComponent<CinemachinePOV>();

        if(senseSlider != null)
        {
            vCamPOVComponent.m_HorizontalAxis.m_MaxSpeed = senseSlider.value;
            vCamPOVComponent.m_VerticalAxis.m_MaxSpeed = senseSlider.value;
        }
    }

    public void SetNewSense()
    {
        float newSense = senseSlider.value;

        vCamPOVComponent.m_HorizontalAxis.m_MaxSpeed = senseSlider.value;
        vCamPOVComponent.m_VerticalAxis.m_MaxSpeed = senseSlider.value;
    }

    public void SetNewVolume()
    {

    }
}
