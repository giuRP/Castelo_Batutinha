using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_options_script : MonoBehaviour
{
    public actual_save_data save_data;


    private void Start()
    {

        save_data = new actual_save_data(data_saver_script.loadsavedata());

        
        
        p1keyboardselect();
        p2gamepadselect();
    }

    public void p1gamepadselect()
    {
         save_data.p1OnKeyboard = false;
        save_data.p1OnGamepad = true;
    }

    public void p1keyboardselect()
    {
        save_data.p1OnKeyboard = true;
        save_data.p1OnGamepad = false;
    }

    public void p2gamepadselect()
    {
        save_data.p2OnKeyboard = false;
        save_data.p2OnGamepad = true;
    }

    public void p2keyboardselect()
    {
        save_data.p2OnKeyboard = true;
        save_data.p2OnGamepad = false;
    }



    public void togglemultiplayer()
    {
        if (save_data.player2InGame)
        {
            save_data.player2InGame = false;
        }
        else 
        {
            save_data.player2InGame = true;
        }
        
    }

    public void deleteSaveData()
    {
        data_saver_script.savedata(new actual_save_data(null));
    }

    public void saveData()
    {

        data_saver_script.savedata(save_data);

    }


}
