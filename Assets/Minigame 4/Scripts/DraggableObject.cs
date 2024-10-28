using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public enum DataTypes
{
    Privacy,
    Public
}

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;

    private Image image;
    public DataTypes dataType;
    public List<TextDataSO> dataList = new();
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        GetRandomData();

        DraggableObject draggableObject = GetComponent<DraggableObject>();
    }

    public void GetRandomData()
    {
        int randomIndex = Random.Range(0, dataList.Count);
        image.sprite = dataList[randomIndex].cardSprite;
        dataType = dataList[randomIndex].dataType;
    }

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
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.GetChild(0).gameObject.SetActive(false);

        if (!eventData.pointerCurrentRaycast.isValid)
        {
            rectTransform.position = startPosition;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // get the children 1 game object
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // get the children 1 game object
        transform.GetChild(0).gameObject.SetActive(false);
    }


}
