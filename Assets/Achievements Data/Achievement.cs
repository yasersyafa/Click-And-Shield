using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Achievement", fileName = "NewAchievement")]
public class Achievement : ScriptableObject
{
    public Sprite card;
    public string title;
    [TextArea(3, 10)]
    public string description;
    public int scoreRequired;
    public bool isUnlocked;

    public void Unlock() {
        isUnlocked = true;
    }
}
