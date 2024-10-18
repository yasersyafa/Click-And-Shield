using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DropZone : MonoBehaviour, IDropHandler
{
    public DraggableObject.ObjectType acceptedType;
    public MiniGameManager miniGameManager;
    
    public void OnDrop(PointerEventData eventData)
    {
        DraggableObject draggableObject = eventData.pointerDrag.GetComponent<DraggableObject>();

        if (draggableObject !=null)
        {
            if (draggableObject.objectType == acceptedType)
            {
                draggableObject.transform.DOScale(draggableObject.transform.localScale, 0.2f)
                    .SetEase(Ease.InBack)
                    .OnComplete(() =>
                    {
                        miniGameManager.WinGame();
                        Destroy(draggableObject.gameObject);
                        /*                miniGameManager.AddPoint();*/
                    });
            }
            else
            {
                draggableObject.transform.DOScale(draggableObject.transform.localScale, 0.2f)
                    .SetEase(Ease.InBack)
                    .OnComplete(() =>
                    {
                      //For incorect object
                      Destroy(draggableObject.gameObject);
                      miniGameManager.GameOver();
                  });
            }
        }
    }
}
