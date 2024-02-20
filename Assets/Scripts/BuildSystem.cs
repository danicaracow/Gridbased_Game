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
