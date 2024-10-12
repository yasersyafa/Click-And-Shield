using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int highScore;
    public List<string> unlockedAchievements = new();

    // constructor
    public PlayerData(int score, List<string> achievements) {
        highScore = score;
        unlockedAchievements = achievements;
    }
}
