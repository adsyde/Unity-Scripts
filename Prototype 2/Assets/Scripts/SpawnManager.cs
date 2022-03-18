using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15.0f;
    private float spawnRangeZ = 15.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        // Repeatedly spawns animals
        InvokeRepeating("ExecuteFunctionByIndex", startDelay, spawnInterval);
    }

    void ExecuteFunctionByIndex()
    {
        // Selects a random function to determine top, left, or right spawns
        int locationIndex = Random.Range(0, 3);
        switch (locationIndex)
        {
            case 0:
                SpawnRandomAnimalTop();
                break;
            case 1:
                SpawnRandomAnimalLeft();
                break;
            case 2:
                SpawnRandomAnimalRight();
                break;
        }
    }

    void SpawnRandomAnimalTop()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosTop = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);

        Instantiate(animalPrefabs[animalIndex], spawnPosTop, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeft()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosLeft = new Vector3(-spawnRangeX - 5, 0, Random.Range(-5, 15));

        Instantiate(animalPrefabs[animalIndex], spawnPosLeft, Quaternion.Euler(0, 90, 0));
    }

    void SpawnRandomAnimalRight()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosRight = new Vector3(spawnRangeX + 5, 0, Random.Range(-5, 15));

        Instantiate(animalPrefabs[animalIndex], spawnPosRight, Quaternion.Euler(0, -90, 0));
    }
}
