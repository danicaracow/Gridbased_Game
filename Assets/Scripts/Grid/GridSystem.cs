using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private float scale = 0.1f;
    [SerializeField] private GridObject[,] gridObjects; 
    [SerializeField] private int gridSize;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject waterPrefab;

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
        float xOffset = Random.Range(-10000f, 10000f);
        float yOffset = Random.Range(-10000f, 10000f);

        float[,] noiseMap = new float[size, size];
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
            {
                
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffset, y * scale + yOffset);
                noiseMap[x, y] = noiseValue;
            }

        gridObjects = new GridObject[size, size];
        for (int x = 0; x < size; x++)
            for (int y = 0;y < size; y++)
            {
                if (noiseMap[x, y] < 0.7f) Instantiate(groundPrefab, new Vector3(x, 0, y), Quaternion.identity);
                else Instantiate(waterPrefab, new Vector3(x, 0, y), Quaternion.identity);
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
