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
            badges[i].sprite = achievementManager.achievements[achievement] ? achievement.card : lockedSprite;
        }
    }
}
