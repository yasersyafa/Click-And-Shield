using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public List<Achievement> allAchievements;
    public List<Achievement> unlockedAchievements = new();

    public void CheckForAchievement(int score) {
        foreach(var achievement in allAchievements) {
            if(!unlockedAchievements.Contains(achievement) && score >= achievement.scoreRequired) {
                UnlockAchievement(achievement);
            }
        }
    }

    private void UnlockAchievement(Achievement achievement) {
        unlockedAchievements.Add(achievement);
        // GameManager.instance.SaveData();
    }

    public List<Achievement> GetUnlockedAchievemnts() {
        return unlockedAchievements;
    }
}
