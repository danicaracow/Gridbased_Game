using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private Vector3 size;
    [SerializeField] private int gridSize;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject waterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gridSize; i++)
        {
            Vector3 nextiPosition = transform.position + new Vector3(transform.position.x + (float)i, transform.position.y, transform.position.z);
            Instantiate(groundPrefab, nextiPosition, Quaternion.identity);
            for (int j = 1; j < gridSize; j++)
            {
                Vector3 nextjPosition = nextiPosition + new Vector3(transform.position.x, transform.position.y, transform.position.z + (float)j);
                Instantiate(groundPrefab, nextjPosition, Quaternion.identity);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
