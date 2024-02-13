using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameVariables : MonoBehaviour
{
    [SerializeField] private int mineNumber;
    [SerializeField] private int farmNumber;

    [SerializeField] private UIManager UImanager;
    private BuildManager buildManager;




    private void Start()
    {
        buildManager = GetComponent<BuildManager>();
        buildManager.OnBuild += BuildManager_OnBuild;
        buildManager.OnDestroy += BuildManager_OnDestroy;

        mineNumber = 0;
        farmNumber = 0;
    }

    

    private void IncreaseBuildingNumber(GameObject builtBuilding)
    {
        Building buildingType = builtBuilding.GetComponent<Building>();

        switch (buildingType.Type)
        {
            case Building.buildingTypes.Mine:
                mineNumber++;
                break;

            case Building.buildingTypes.Farm:
                farmNumber++;
                break;
        }

        UImanager.UpdateBuildingNumber(mineNumber, farmNumber);
    }

    private void DecreaseBuildingNumber(GameObject builtBuilding)
    {
        Building buildingType = builtBuilding.GetComponent<Building>();

        switch (buildingType.Type)
        {
            case Building.buildingTypes.Mine:
                mineNumber--;
                break;

            case Building.buildingTypes.Farm:
                farmNumber--;
                break;
        }

        UImanager.UpdateBuildingNumber(mineNumber, farmNumber);
    }



    private void BuildManager_OnBuild(object sender, BuildManager.OnBuildEventArgs e)
    {
        IncreaseBuildingNumber(e.builtBuilding);
    }

    private void BuildManager_OnDestroy(object sender, BuildManager.OnBuildEventArgs e)
    {
        DecreaseBuildingNumber(e.builtBuilding);
    }
}
