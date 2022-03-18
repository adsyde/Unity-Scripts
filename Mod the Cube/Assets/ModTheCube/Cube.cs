using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;

    private float randomGenerationTimer = 0f;

    private float minRGB = 0f;
    private float maxRGB = 5f;

    private float positionRange = 5f;
    private Vector3 newPosition;
    private float rotationRange = 15f;
    private Vector3 newRotation;
    private float scaleRange = 3f;
    private Vector3 newScale;

    private void Awake()
    {
        material = Renderer.material;
    }
    void Start()
    {
        RandomGeneration();
    }

    void Update()
    {
        randomGenerationTimer += Time.deltaTime;
        if (randomGenerationTimer >= 5f)
        {
            RandomGeneration();
            randomGenerationTimer = 0;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
        transform.Rotate(newRotation.x * Time.deltaTime, newRotation.y * Time.deltaTime, newRotation.z * Time.deltaTime);
        transform.localScale = new Vector3(newScale.x, newScale.y, newScale.z);
    }

    void RandomGeneration()
    {
        //Generates a new position
        newPosition = new Vector3(Random.Range(-positionRange, positionRange), Random.Range(-positionRange, positionRange), Random.Range(-positionRange, positionRange));

        //Generates a new rotation
        newRotation = new Vector3(Random.Range(-rotationRange, rotationRange), Random.Range(-rotationRange, rotationRange), Random.Range(-rotationRange, rotationRange));

        //Generate a new scale
        newScale = new Vector3(Random.Range(-scaleRange, scaleRange), Random.Range(-scaleRange, scaleRange), Random.Range(-scaleRange, scaleRange));

        //Generates a new colour
        material.color = new Color(Random.Range(minRGB, maxRGB), Random.Range(minRGB, maxRGB), Random.Range(minRGB, maxRGB), 1f);
    }

}