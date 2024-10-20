using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextData", menuName = "ScriptableObject/TextData")]

public class TextDataSO : ScriptableObject
{
    [System.Serializable]
    public class TextData
    {
        public string text;
        public DraggableObject.ObjectType objectType;
    }

    public List<TextData> TextDataList;
}
