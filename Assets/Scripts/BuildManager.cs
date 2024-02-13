using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] GameObject[] buildingList;
    private Building.buildingTypes selectedBuildingType;
    private int buildingIndex;

    public event EventHandler<OnBuildEventArgs> OnBuild;
    public event EventHandler<OnBuildEventArgs> OnDestroy;
    public class OnBuildEventArgs : EventArgs
    {
        public Building.buildingTypes buildingType;
        public bool increaseNumber;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBuildingType = Building.buildingTypes.Mine;
            buildingIndex = (int)selectedBuildingType;
            Debug.Log("Mine selected!");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBuildingType = Building.buildingTypes.Farm;
            buildingIndex = (int)selectedBuildingType;
            Debug.Log("Farm selected!");
        }
    }

    public GameObject BuildingGetter()
    {
        return buildingList[buildingIndex];
    }

    public void Build(Vector3 position)
    {
        Building.buildingTypes builtType = buildingList[buildingIndex].GetComponent<Building>().GetBuildingType();

        Instantiate(buildingList[buildingIndex], position, Quaternion.identity);

        OnBuild?.Invoke(this, new OnBuildEventArgs { buildingType = builtType, increaseNumber = true });

    }

    public void DestroyBuilding(GameObject building)
    {
        Building.buildingTypes builtType = building.GetComponent<Building>().GetBuildingType();

        Destroy(building);

        OnDestroy?.Invoke(this, new OnBuildEventArgs { buildingType = builtType, increaseNumber = false });
    }

}
