using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenuControll : MonoBehaviour
{
    public void LoadGame()
    {
        ScenesManager.Instance.LoadNextScene();
    }

    public void QuitGame()
    {
        ScenesManager.Instance.QuitGame();
    }
}
