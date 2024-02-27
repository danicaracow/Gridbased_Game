using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] GameObject[] buildingList;
    private Building.buildingTypes selectedBuildingType;
    private int buildingIndex;

    public event EventHandler<OnBuildEventArgs> OnBuild;
    public event EventHandler<OnBuildEventArgs> OnDestroy;


    public static BuildSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public class OnBuildEventArgs : EventArgs
    {
        public Building Building;
        public bool increaseNumber;
        public Vector3 buildingPosition;
    }

    public GameObject BuildingGetter()
    {
        return buildingList[buildingIndex];
    }

    public void Build(Vector3 position)
    {
        Building Building = buildingList[buildingIndex].GetComponent<Building>();

        Instantiate(buildingList[buildingIndex], position, Quaternion.identity);

        OnBuild?.Invoke(this, new OnBuildEventArgs { Building = Building, increaseNumber = true, buildingPosition = position });

    }

    public void DestroyBuilding(GameObject building)
    {
        Building Building = building.GetComponent<Building>();

        Destroy(building);

        //Need to pass building position as EventArg
        OnDestroy?.Invoke(this, new OnBuildEventArgs { Building = Building, increaseNumber = false });
    }

    public void OnMineSelectButtonPressed()
    {
        selectedBuildingType = Building.buildingTypes.Mine;
        buildingIndex = (int)selectedBuildingType;
    }

    public void OnFarmSelectButtonPressed()
    {
        selectedBuildingType = Building.buildingTypes.Farm;
        buildingIndex = (int)selectedBuildingType;
    }
}
