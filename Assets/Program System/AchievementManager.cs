using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public Dictionary<Achievement, bool> achievements = new();
    public List<Achievement> allAchievements;

    void Start() {
        // foreach(var badge in allAchievements) {
        //     achievements[badge] = false;
        // }
    }

    public void CheckForAchievement(int score) {
        foreach(var achievement in allAchievements) {
            if(score >= achievement.scoreRequired) {
                UnlockAchievement(achievement);
            }
        }
    }

    private void UnlockAchievement(Achievement badge) {
        if(!achievements.ContainsKey(badge)) {
            achievements.Add(badge, true);
        }
        else {
            achievements[badge] = true;
        }
        
        Debug.Log($"You have got the badge: {badge.title}");
    }

    public Achievement GetDetailBadge(Achievement badge) {
        return badge;
    }

    public bool GetBadge(Achievement badge) {
        return achievements.ContainsKey(badge) ? true : false;
    }
}
