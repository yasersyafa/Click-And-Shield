using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    // public Dictionary<Achievement, bool> achievements = new();
    public List<Achievement> allAchievements = new();
    private List<string> unlockedAchievements = new();
    public Queue<Achievement> rewardQueue = new();

    public void CheckForAchievement(int score) {
        foreach(var achievement in allAchievements) {
            if(score >= achievement.scoreRequired && !IsAchievementUnlocked(achievement.title)) {
                UnlockAchievement(achievement);
            }
        }
    }

    private void UnlockAchievement(Achievement badge) {
        AddRewardToQueue(badge);
        unlockedAchievements.Add(badge.title);
    }

    public bool IsAchievementUnlocked(string title) {
        return unlockedAchievements.Contains(title);
    }

    public void AddRewardToQueue(Achievement badge) {
        if(!IsAchievementUnlocked(badge.title)) {
            rewardQueue.Enqueue(badge);
            Debug.Log($"Kamu mendapatkan: {badge.title}");
        }
    }

    public List<string> GetUnlockedAchievements() {
        return new List<string>(unlockedAchievements);
    }

    public Achievement GetDetailBadge(Achievement badge) {
        return badge;
    }

    public void LoadAchievements(List<string> savedAchievements) {
        unlockedAchievements = new List<string>(savedAchievements);
    }
}
