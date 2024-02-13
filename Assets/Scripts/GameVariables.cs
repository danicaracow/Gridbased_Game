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
        buildManager.OnBuild += MouseSelection_OnBuild;

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


    private void MouseSelection_OnBuild(object sender, BuildManager.OnBuildEventArgs e)
    {
        IncreaseBuildingNumber(e.builtBuilding);
    }
}
