using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public DraggableObject.ObjectType acceptedType;
    public MiniGameManager miniGameManager;

    private Vector3 originalScale; 

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableObject draggableObject = eventData.pointerDrag.GetComponent<DraggableObject>();

        if (draggableObject != null)
        {
            if (draggableObject.objectType == acceptedType)
            {
                Debug.Log("Benar");
                Destroy(draggableObject.gameObject);
                miniGameManager.WinGame();
            }
            else
            {
                // Untuk objek yang salah
                Debug.Log("Salah");
                Destroy(draggableObject.gameObject);
                miniGameManager.GameOver();
            }
        }

        ResetDropZoneScale();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AnimateDropZoneScaleUp();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetDropZoneScale();
    }

    private void AnimateDropZoneScaleUp()
    {
        transform.DOScale(originalScale * 1.2f, 0.2f).SetEase(Ease.OutBack);
    }

    private void ResetDropZoneScale()
    {
        transform.DOScale(originalScale, 0.2f).SetEase(Ease.OutBack);
    }
}
