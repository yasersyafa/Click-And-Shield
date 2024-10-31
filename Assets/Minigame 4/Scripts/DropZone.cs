using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using dataRush;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public DataTypes acceptedType;
    private MinigameStateManager stateManager;

    private Vector3 originalScale; 

    private void Start()
    {
        originalScale = transform.localScale;
        stateManager = FindObjectOfType<MinigameStateManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableObject draggableObject = eventData.pointerDrag.GetComponent<DraggableObject>();

        if (draggableObject != null)
        {
            if (draggableObject.dataType == acceptedType)
            {
                Debug.Log("Benar");
                Destroy(draggableObject.gameObject);
                stateManager.SetState(new dataRush.WinState(stateManager));
            }
            else
            {
                // Untuk objek yang salah
                Debug.Log("Salah");
                Destroy(draggableObject.gameObject);
                stateManager.SetState(new dataRush.LoseState(stateManager));
                
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
