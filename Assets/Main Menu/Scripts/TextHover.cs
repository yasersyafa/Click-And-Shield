using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI text;
    private Color normalColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = new Color32(255, 186, 140, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = normalColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        normalColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
