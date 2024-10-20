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

    // public AchievementCard() {
    //     card.sprite = UpdateCard();
    // }

    // Start is called before the first frame update
    void Start()
    {
        achievementManager = GameObject.Find("Achievement Manager").GetComponent<AchievementManager>();
        card = GetComponent<Image>();
        card.sprite = UpdateCard();
        
        
    }

    private Sprite UpdateCard()
    {
        Debug.Log($"sprite: {card.sprite.name}");
        if(achievementManager.GetBadge(badge)) {
            return badge.card;
        }
        else return lockedSprite;
        // return achievementManager.GetBadge(badge) ? badge.card : lockedSprite; 
    }
}
