using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OutlinePhoneAnimation : MonoBehaviour
{
    public Vector3 targetScale = new(2.5f, 2.5f, 2.5f);
    float targetAlpha = 0f; //opacity
    public float duration = 0.5f;
    private Image outlineImage;
    // Start is called before the first frame update
    void Start()
    {
        outlineImage = GetComponent<Image>();
        StartAnimatingOutline();
    }

    private void StartAnimatingOutline()
    {
        transform.DOScale(targetScale, duration).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Restart);
        outlineImage.DOFade(targetAlpha, duration).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Restart);
    }
}
