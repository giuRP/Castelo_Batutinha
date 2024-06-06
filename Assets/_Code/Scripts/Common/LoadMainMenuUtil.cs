using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenuUtil : MonoBehaviour
{
    public void LoadMainMenu()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }
}
