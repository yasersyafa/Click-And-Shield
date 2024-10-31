using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int highScore;
    public List<string> achievements = new();

    // constructor
    public PlayerData(int score, List<string> badge) {
        highScore = score;
        achievements = badge;
    }
}
