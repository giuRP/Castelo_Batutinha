using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class actual_save_data 
{
    public bool player2InGame = false;

    public bool p1OnKeyboard = true;
    public bool p2OnKeyboard = false;
    public bool p1OnGamepad = false;
    public bool p2OnGamepad = true;

    public int p1health = 3;
    public int p2health = 3;
    public int lifes = 5;

    public float lastcheckpointX;
    public float lastcheckpointY;
    

    public bool p1hasBrella;
    public bool p2hasBrella;

    public int score;


    

    public actual_save_data (actual_save_data newdata)
    {
        if (newdata != null)
        {
            player2InGame = newdata.player2InGame;

            p1OnKeyboard = newdata.p1OnKeyboard;
            p2OnKeyboard = newdata.p2OnKeyboard;
            p1OnGamepad = newdata.p1OnGamepad;
            p2OnGamepad = newdata.p2OnGamepad;

            p1health = newdata.p1health;
            p2health = newdata.p2health;

            lifes = newdata.lifes;

            lastcheckpointX = newdata.lastcheckpointX;
            lastcheckpointY = newdata.lastcheckpointY;
            

            p1hasBrella = newdata.p1hasBrella;
            p2hasBrella = newdata.p2hasBrella;


            score = newdata.score;


        }
    }
   
}
