using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fecharJogo : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("game_scene");
       


    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void goMainMenu()
    {
        
        SceneManager.LoadScene("main_menu_scene");


    }

    public void actuallyPlayGame()
    {

        SceneManager.LoadScene("Level1");


    }


}
