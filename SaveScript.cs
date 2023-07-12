using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveScript 
{
    public int healthValue;

    public int ScoreValue;

    public float playerPositionX;

    public float playerPositionY;

    public SaveScript() { }

    public SaveScript(int health, int Score, float x , float y) {
        healthValue = health;
        ScoreValue = Score;
        playerPositionX = x;
        playerPositionY = y;
    }


}
