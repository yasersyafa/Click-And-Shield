using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class ObjectSpawner : MonoBehaviour
{
    public TextDataSO textDataSO;
    public GameObject draggablePrefab; 
    public Transform spawnPoint;
    public Transform parentPanel;

    private void Start()
    {
        SpawnRandomObject();
    }

    public void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, textDataSO.TextDataList.Count);
        TextDataSO.TextData selectedTextData = textDataSO.TextDataList[randomIndex];

        GameObject spawnedObject = Instantiate(draggablePrefab, spawnPoint.position, Quaternion.identity, parentPanel);
        spawnedObject.GetComponent<RectTransform>().anchoredPosition = spawnPoint.GetComponent<RectTransform>().anchoredPosition;

        TextMeshProUGUI textComponent = spawnedObject.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = selectedTextData.text;
        }

        DraggableObject draggableObject = spawnedObject.GetComponent<DraggableObject>();
        if (draggableObject != null)
        {
            draggableObject.objectType = selectedTextData.objectType;
        }
    }
}
