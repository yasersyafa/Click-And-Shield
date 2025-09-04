using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIButtonAnim : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private float EffectStrength = 1.2f;
    [SerializeField] private float EffectDuration = 0.2f;
    [SerializeField] private Ease bounceEase = Ease.OutBack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// Animates the button with a bounce effect using DOTween
    /// </summary>
    public void ButtonBounce()
    {
        // Kill any existing scale tweens on this transform to prevent conflicts
        transform.DOKill();
        
        // Reset scale to original size first
        transform.localScale = Vector3.one;
        
        // Create the bounce animation sequence
        Sequence bounceSequence = DOTween.Sequence();
        
        // Scale up to bounce scale, then back to original
        bounceSequence.Append(transform.DOScale(EffectStrength, EffectDuration / 2f).SetEase(bounceEase))
                     .Append(transform.DOScale(1f, EffectDuration / 2f).SetEase(Ease.OutBounce));
        
        // Play the sequence
        bounceSequence.Play();
    }
}
