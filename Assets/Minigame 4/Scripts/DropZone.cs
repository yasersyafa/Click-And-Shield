using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

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
                Destroy(draggableObject.gameObject);
/*                miniGameManager.AddPoint();*/
            }
            else
            {
                //For incorect object
                Destroy(draggableObject.gameObject);
                miniGameManager.GameOver();
            }
        }
    }
}
