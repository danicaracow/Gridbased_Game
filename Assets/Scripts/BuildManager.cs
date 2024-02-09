using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] GameObject[] buildingList;
    private int buildingIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            buildingIndex = 0;
            Debug.Log("Mine selected!");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            buildingIndex = 1;
        }
    }

    public GameObject BuildingGetter()
    {
        return buildingList[buildingIndex];
    }
}
