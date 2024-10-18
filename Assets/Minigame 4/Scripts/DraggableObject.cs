using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum ObjectType {TypeA, TypeB}
    public ObjectType objectType;


    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.position;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (!eventData.pointerCurrentRaycast.isValid)
        {
            rectTransform.position = startPosition;
        }
    }
}
