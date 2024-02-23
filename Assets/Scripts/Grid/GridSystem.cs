using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private float scale = 0.1f;
    [SerializeField] private Transform[,] gridObjects; 
    [SerializeField] private int gridSize;
    [SerializeField] private Transform groundPrefab;
    [SerializeField] private Transform waterPrefab;
    [SerializeField] private Transform foodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < gridSize; i++)
        //{
        //    Vector3 nextiPosition = transform.position + new Vector3(transform.position.x + (float)i, transform.position.y, transform.position.z);
        //    Instantiate(groundPrefab, nextiPosition, Quaternion.identity);
        //    for (int j = 1; j < gridSize; j++)
        //    {
        //        Vector3 nextjPosition = nextiPosition + new Vector3(transform.position.x, transform.position.y, transform.position.z + (float)j);
        //        Instantiate(groundPrefab, nextjPosition, Quaternion.identity);
        //    }

        //}
        float xOffsetWater = Random.Range(-10000f, 10000f);
        float yOffsetWater = Random.Range(-10000f, 10000f);
        float xOffsetFood = Random.Range(-10000f, 10000f);
        float yOffsetFood = Random.Range(-10000f, 10000f);

        float[,] noiseMapWater = new float[size, size];
        float[,] noiseMapFood = new float[size, size];
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
            {
                float noiseValueWater = Mathf.PerlinNoise(x * scale + xOffsetWater, y * scale + yOffsetWater);
                noiseMapWater[x, y] = noiseValueWater;

                float noiseValueFood = Mathf.PerlinNoise(x * scale + xOffsetFood, y * scale + yOffsetFood);
                noiseMapFood[x, y] = noiseValueFood;
            }

        gridObjects = new Transform[size, size];
        for (int x = 0; x < size; x++)
            for (int y = 0;y < size; y++)
            {
                if (noiseMapWater[x, y] < 0.7f)
                {
                    gridObjects[x, y] = Instantiate(groundPrefab, new Vector3(x, 0, y), Quaternion.identity);
                    gridObjects[x, y].GetComponent<GridObject>().ObjectType = GridObject.GridObjectType.Ground;
                }

                else 
                {
                    gridObjects[x, y] = Instantiate(waterPrefab, new Vector3(x, 0, y), Quaternion.identity);
                    gridObjects[x, y].GetComponent<GridObject>().ObjectType = GridObject.GridObjectType.Water;
                }

                
            }

        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
            {
                switch (gridObjects[x, y].GetComponent<GridObject>().ObjectType)
                {
                    case GridObject.GridObjectType.Water:
                        continue;

                    case GridObject.GridObjectType.Ground:
                        if (noiseMapFood[x, y] > 0.7)
                        {
                            Destroy(gridObjects[x, y].gameObject);
                            gridObjects[x, y] = Instantiate(foodPrefab, new Vector3(x, 0, y), Quaternion.identity);
                        }
                        break;
                }
            }
    }


    //private void OnDrawGizmos()
    //{
    //    for (int i = 0; i < gridSize; i++)
    //    {
    //        Vector3 nextiPosition = transform.position + new Vector3(transform.position.x + (float)i, transform.position.y, transform.position.z);
    //        Gizmos.DrawCube(nextiPosition, size);
    //        for (int j = 1; j < gridSize; j++)
    //        {
    //            Vector3 nextjPosition = nextiPosition + new Vector3(transform.position.x, transform.position.y, transform.position.z + (float)j);
    //            Gizmos.DrawCube(nextjPosition, size);
    //        }
            
    //    }
        
    //}
}
