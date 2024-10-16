using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public DraggableObject.ObjectType acceptedType;
    public GameManager gameManager;

    
    public void OnDrop(PointerEventData eventData)
    {
        DraggableObject draggableObject = eventData.pointerDrag.GetComponent<DraggableObject>();

        if (draggableObject !=null)
        {
/*            if (draggableObject == acceptedType)
            {
                Destroy(draggableObject.gameObject);
                gameManager
            }*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
