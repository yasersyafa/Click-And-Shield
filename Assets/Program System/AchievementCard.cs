using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCard : MonoBehaviour
{
    public Achievement badge;
    public Sprite lockedSprite;
    private Image card;
    AchievementManager achievementManager; 

    // Start is called before the first frame update
    void Start()
    {
        achievementManager = GameObject.Find("Achievement Manager").GetComponent<AchievementManager>();
        card = GetComponent<Image>();
        UpdateCard();
        
    }

    private void UpdateCard() {
        if (achievementManager.IsAchievementUnlocked(badge.title)) {
            // Jika achievement sudah terbuka, tampilkan sprite achievement
            card.sprite = badge.card;
        } else {
            // Jika achievement belum terbuka, tampilkan sprite locked
            card.sprite = lockedSprite;
        }
    }
}
