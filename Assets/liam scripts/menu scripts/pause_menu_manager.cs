using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;


public class pause_menu_manager : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public UnityEvent resume_event;
    public UnityEvent pause_event;
    public UnityEvent start_event;
    public float newSens;
    public Slider sensSlider;

    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        start_event.Invoke();
    }

    private void Start()
    {
        virtualCamera = CameraManager.Instance.playerVCam;

        if (virtualCamera == null)
        {
            Debug.LogError("Virtual Camera not assigned!");
            return;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
            //pauseflip();


        //}
    }


    public void pauseflip()
    {
        if (Time.timeScale == 0 && !gameIsPaused)
            return;

        if (gameIsPaused)
        {
            resume();


        }
        else
        {
            
            pause();
        }
    }

    public void pause()
    { 
        pause_event.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //cam stuff
        var aimAxis = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

        if (aimAxis != null)
        {
            newSens = aimAxis.m_HorizontalAxis.m_MaxSpeed;
        }
        
        setSlider();
        //


        Time.timeScale = 0f;
        gameIsPaused = true;


    }

    public void resume()
    { 
        resume_event.Invoke();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //cam stuff
        newSens = sensSlider.value;

        var aimAxis = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        if (aimAxis != null)
        {
            aimAxis.m_HorizontalAxis.m_MaxSpeed = newSens;
            aimAxis.m_VerticalAxis.m_MaxSpeed = newSens;
        }
        //cam stuff

        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void setSens(float newsens)
    {
        newSens = newsens;
    }

    public void setSlider()
    {
        newSens = Mathf.Clamp(newSens, sensSlider.minValue, sensSlider.maxValue);

        
        sensSlider.value = newSens;
    }

    public void closeGame()
    { 
        Application.Quit();
    }


}
