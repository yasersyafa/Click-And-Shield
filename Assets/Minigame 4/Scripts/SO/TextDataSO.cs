using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextData", menuName = "ScriptableObject/TextData")]

public class TextDataSO : ScriptableObject
{
    public Sprite cardSprite;
    public DataTypes dataType;
}
