using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject typeAPrefab;
    public GameObject typeBPrefab;
    public Transform spawnPoint;
    public Transform parentPanel;

    private void Start()
    {
        SpawnRandomObject();
    }

    public void SpawnRandomObject()
    {
        int randomChoice = Random.Range(0, 2);
        Debug.Log("Random Choice :" + randomChoice);

        GameObject objectToSpawn = null;

        if (randomChoice == 0)
        {
            objectToSpawn = typeAPrefab;
        }
        else
        {
            objectToSpawn = typeBPrefab;
        }

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity, parentPanel);

        spawnedObject.GetComponent<RectTransform>().anchoredPosition = spawnPoint.GetComponent<RectTransform>().anchoredPosition;
    }
}
