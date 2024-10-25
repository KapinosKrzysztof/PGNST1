using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    public int numberOfObjects = 10;
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    
    public GameObject block;
    public Material[] materials;

    void Start()
    {
        Bounds platformBounds = GetComponent<Collider>().bounds;
        float spawnHeight = platformBounds.max.y + 0.5f;

        List<float> posX = new List<float>(GenerateRandomPositions(platformBounds.min.x, platformBounds.max.x, numberOfObjects));
        List<float> posZ = new List<float>(GenerateRandomPositions(platformBounds.min.z, platformBounds.max.z, numberOfObjects));

        for (int i = 0; i < numberOfObjects; i++)
        {
            positions.Add(new Vector3(posX[i], spawnHeight, posZ[i]));
        }

        foreach (Vector3 position in positions)
        {
            Debug.Log(position);
        }

        StartCoroutine(SpawnObjects());
    }

    void Update()
    {

    }

    List<float> GenerateRandomPositions(float min, float max, int count)
    {
        List<float> positions = new List<float>();

        while (positions.Count < count)
        {
            float randomPosition = UnityEngine.Random.Range(min, max);
            positions.Add(randomPosition);
        }

        return positions;
    }

    IEnumerator SpawnObjects()
    {
        Debug.Log("Coroutine started");
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);
            Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
            newBlock.GetComponent<Renderer>().material = randomMaterial;

            yield return new WaitForSeconds(delay);
        }

        StopCoroutine(SpawnObjects());
    }
}
