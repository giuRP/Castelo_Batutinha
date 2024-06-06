using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInGameMenuControll : MonoBehaviour
{
    [SerializeField]
    private GameObject InGameMenu;

    [SerializeField]
    private Agent agent;

    private void OnEnable()
    {
        GameManager.Instance.OnPauseGame += ActivateInGameMenu;
        GameManager.Instance.OnResumeGame += DeactivateInGameMenu;
    }

    private void OnDisable()
    {
        //Debug.Log(GameManager.Instance == null);
        GameManager.Instance.OnPauseGame -= ActivateInGameMenu;
        GameManager.Instance.OnResumeGame -= DeactivateInGameMenu;
    }

    private void Start()
    {
        InGameMenu = transform.GetChild(0).gameObject;
        InGameMenu.SetActive(false);

        agent = GetComponentInParent<Agent>();
    }

    public void PauseGame()
    {
        GameManager.Instance.GamePauseControll();
    }

    public void ReturnToMainMenu()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }

    public void BlockInput()
    {
        agent.input.IsInputBlocked = true;
    }

    public void UnblockInput()
    {
        agent.input.IsInputBlocked = false;
    }

    private void ActivateInGameMenu()
    {
        //Debug.Log("Activate");
        InGameMenu.SetActive(true);
    }   
    
    private void DeactivateInGameMenu()
    {
        //Debug.Log("Deactivate");
        InGameMenu.SetActive(false);
    }
}
