using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;

    public float playerCurrentHealth;

    public SerializableDictionary<string, bool> EnemiesKilled;
    public SerializableDictionary<string, bool> AmmoBoxesCollected;

    public Vector3 playerPosition;
    //the values defined here will be the default values
    public GameData()
    {
        this.playerCurrentHealth = 50f;
        this.playerPosition = Vector3.zero;
        EnemiesKilled = new SerializableDictionary<string, bool>();
        AmmoBoxesCollected = new SerializableDictionary<string, bool>();
    }

    //you can incorporate TMPro elements by refering them to here and it will update in the SaveSlot.cs class
}
