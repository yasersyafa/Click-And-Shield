using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementCard : MonoBehaviour
{
    public Achievement badge;
    public Sprite lockedSprite;
    private Image card;
    [Space]
    [Header("Panel Detail")]
    public GameObject panelDetail;
    public Image cardDetail;
    public TextMeshProUGUI titleText, descText;
    private Button buttonCard;
    AchievementManager achievementManager; 

    // Start is called before the first frame update
    void Start()
    {
        achievementManager = GameObject.Find("Achievement Manager").GetComponent<AchievementManager>();
        card = GetComponent<Image>();
        buttonCard = GetComponent<Button>();
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

    public void OnCardClick(Achievement badge) {
        if (achievementManager.IsAchievementUnlocked(badge.title)) {
            panelDetail.SetActive(true);
            
            cardDetail.sprite = badge.card;
            titleText.text = badge.title;
            descText.text = badge.description;
        } else {
            panelDetail.SetActive(true);
            
            cardDetail.sprite = lockedSprite;
            titleText.text = "????";
            descText.text = $"You can unlock this achievement once you reach <b><color=#7C96B5>{badge.scoreRequired.ToString()}</color></b> score.";
        }
    }
}
