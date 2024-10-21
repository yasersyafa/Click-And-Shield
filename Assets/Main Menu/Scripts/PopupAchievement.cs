using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupAchievement : MonoBehaviour
{
    public AchievementManager achievementManager;
    public Sprite lockedSprite;
    public Image[] badges;
    // Start is called before the first frame update
    void Start()
    {
        achievementManager = GameObject.Find("Achievement Manager").GetComponent<AchievementManager>();
    }

    public void ShowAchievement() {
        for(int i = 0; i < badges.Length; i++) {
            Achievement achievement = achievementManager.allAchievements[i];
        if(achievementManager.IsAchievementUnlocked(achievement.title)) {
                badges[i].sprite = achievementManager.allAchievements[i].card;
            }
            else {
                badges[i].sprite = lockedSprite;
            }
        }
    }
}
