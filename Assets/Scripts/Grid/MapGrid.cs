using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    public GridSystem gridSystem { get; private set; }
    [SerializeField] private int mapSize;
    [SerializeField] private float scale;
    [SerializeField] private GameObject gridObjectPrefab;
    [SerializeField] private GameResources gameResources;

    public static MapGrid Instance { get; private set; }
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

        gridSystem = new GridSystem(mapSize, scale, gridObjectPrefab, gameResources);
    }

    private void Start()
    {
        BuildSystem.Instance.OnBuild += BuildSystem_OnBuild;
    }

    private void BuildSystem_OnBuild(object sender, BuildSystem.OnBuildEventArgs e)
    {
        GridPosition gridPosition = MouseSelection.Instance.GetGridPosition(e.buildingPosition);

        //GetWorldPosition and GetGridPosition need to be static functions
        SetGridObjectBuilding(gridSystem.GetGridObject(gridPosition), e.Building);
    }

    private void SetGridObjectBuilding(GridObject gridObject, Building building)
    {
        gridObject.Building = building;
        Debug.Log(building.Type);
    }
}
