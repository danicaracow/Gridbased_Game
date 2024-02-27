using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private float scale = 0.1f;
    [SerializeField] private GameResources gameResources;
    private List<GameResources.Resource> orderedResourceList;
    [SerializeField] private GridObject[,] gridObjects;
    [SerializeField] private GameObject[,] gridObjectsVisual;
    [SerializeField] private Transform groundPrefab;
    [SerializeField] private Transform waterPrefab;
    [SerializeField] private Transform foodPrefab;
    [SerializeField] private GameObject gridObjectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        orderedResourceList = gameResources.GetOrderedResourceList();


        //Create GridObject (Ground/Water) array
        float xOffsetGround = Random.Range(-10000f, 10000f);
        float yOffsetGround = Random.Range(-10000f, 10000f);
        gridObjects = new GridObject[size,size];
        float[,] noiseMapGround = new float[size, size];
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
            {
                float noiseValueGround = Mathf.PerlinNoise(x * scale + xOffsetGround, y * scale + yOffsetGround);
                noiseMapGround[x, y] = noiseValueGround;

                if (noiseMapGround[x, y] < gameResources.ground.probability)
                {
                    //SEPARAR GROUND Y WATER DEL RESTO DE RESOURCES EN EL CONSTRUCTOR DE GRIDOBJECT??
                    gridObjects[x, y] = new GridObject(true);
                    gridObjects[x, y].ObjectType = GridObject.GridObjectType.Ground;
                    gridObjects[x, y].isGround = true;
                    gridObjects[x, y].isResource = false;
                    Debug.Log("Ground");
                    Debug.Log(gridObjects[x, y].isResource);

                    //Instantiate(new GridObject(true), new Vector3(x, 0, y), Quaternion.identity);
                }
                else
                {
                    gridObjects[x, y] = new GridObject(false);
                    gridObjects[x, y].ObjectType = GridObject.GridObjectType.Water;
                    gridObjects[x, y].isGround = false;
                    gridObjects[x, y].isResource = false;
                    Debug.Log("Water");
                    Debug.Log(gridObjects[x, y].isResource);
                }
            }


        //Assign rest of resources to ground GridObjects
        
        foreach (GameResources.Resource gameResource in orderedResourceList)
        {
            float[,] noiseMapResource = new float[size, size];
            float xOffsetResource = Random.Range(-10000f, 10000f);
            float yOffsetResource = Random.Range(-10000f, 10000f);

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    if (!gridObjects[x, y].isGround)
                        continue;

                    if (gridObjects[x, y].isResource)
                        continue;

                    float noiseValueResource = Mathf.PerlinNoise(x * scale + xOffsetResource, y * scale + yOffsetResource);
                    noiseMapResource[x, y] = noiseValueResource;

                    if (noiseMapResource[x, y] < gameResource.probability)
                    {
                        Debug.Log(noiseMapResource[x, y]);
                        gridObjects[x, y].resourceName = gameResource.resourceName;
                        gridObjects[x, y].resourceAmount = gameResource.resourceAmount;
                        gridObjects[x, y].material = gameResource.material;
                        gridObjects[x, y].isResource = true;
                    }
                }

        }
        



        //Display visuals
        gridObjectsVisual = new GameObject[size, size];
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
            {
                if (gridObjects[x, y].isResource == false)
                {

                    switch (gridObjects[x, y].ObjectType)
                    {
                        case GridObject.GridObjectType.Ground:
                            gridObjectsVisual[x, y] = Instantiate(gridObjectPrefab, new Vector3(x, 0, y), Quaternion.Euler(new Vector3(90, 0, 0)));
                            gridObjectsVisual[x, y].GetComponent<MeshRenderer>().material = gameResources.ground.material;
                            break;

                        case GridObject.GridObjectType.Water:
                            gridObjectsVisual[x, y] = Instantiate(gridObjectPrefab, new Vector3(x, 0, y), Quaternion.Euler(new Vector3(90, 0, 0)));
                            gridObjectsVisual[x, y].GetComponent<MeshRenderer>().material = gameResources.water.material;
                            break;
                    }
                }


                else
                {
                    gridObjectsVisual[x, y] = Instantiate(gridObjectPrefab, new Vector3(x, 0, y), Quaternion.Euler(new Vector3(90, 0, 0)));
                    gridObjectsVisual[x, y].GetComponent<MeshRenderer>().material = gridObjects[x, y].material;
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
