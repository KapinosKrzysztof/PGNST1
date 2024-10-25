using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; 
    public int numberOfCubes = 10; 
    public Vector2 planeSize = new Vector2(9, 9); 

    private List<Vector3> usedPositions = new List<Vector3>(); 

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GetUniqueRandomPosition();
            Instantiate(cubePrefab, randomPosition, Quaternion.identity); 
        }
    }

    Vector3 GetUniqueRandomPosition()
    {
        Vector3 randomPosition;
        bool positionIsValid;

        do
        {
            
            float x = Random.Range(-4.5f, 4.5f);
            float z = Random.Range(-4.5f, 4.5f);
            randomPosition = new Vector3(x, 0.5f, z);

            
            positionIsValid = !PositionAlreadyUsed(randomPosition);
        }
        while (!positionIsValid);

        usedPositions.Add(randomPosition);
        return randomPosition;
    }

    bool PositionAlreadyUsed(Vector3 position)
    {
        foreach (Vector3 usedPosition in usedPositions)
        {
            
            if (Vector3.Distance(position, usedPosition) < 1) 
            {
                return true; 
            }
        }
        return false; 
    }
}
