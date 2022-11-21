using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float playerHealth;

    //the values defined here will be the default values
    public GameData()
    {
        this.playerHealth = 100f;
    }
}
