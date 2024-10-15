using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject typeAPrefab;
    public GameObject typeBPrefab;
    public Transform spawnPoint;

    private void Start()
    {
        SpawnRandomObject();
    }

    public void SpawnRandomObject()
    {
        int randomChoice = Random.Range(0, 1);

        GameObject objectToSpawn = null;

        if (randomChoice == 0)
        {
            objectToSpawn = typeAPrefab;
        }
        else
        {
            objectToSpawn = typeBPrefab;
        }

        Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
    }


}
