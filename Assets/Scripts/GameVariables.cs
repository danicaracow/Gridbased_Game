using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameVariables : MonoBehaviour
{
    //Start Stats
        //Resource gathering stats
        public float mineGatheringRate { get; private set;}
        public int mineGatheringAmount { get; private set;}
        public float farmGatheringRate { get; private set; }
        public int farmGatheringAmount { get; private set; }


    //Current Stats
        //Building number
        [SerializeField] private int mineNumber;
        [SerializeField] private int farmNumber;

        //Total Resources
        [SerializeField] private int goldAmount;
        [SerializeField] private int foodAmount;


    //References
    private BuildManager buildManager;
    [SerializeField] private BuildingStartStats buildingStartStats;

    public static GameVariables Instance { get; private set; }

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


    private void Start()
    {
        buildManager = GetComponent<BuildManager>();
        buildManager.OnBuild += BuildManager_OnBuildDestroy;
        buildManager.OnDestroy += BuildManager_OnBuildDestroy;

        mineNumber = 0;
        farmNumber = 0;

        //Assign start stats values
        mineGatheringRate = buildingStartStats.mineData.gatheringRate;
        mineGatheringAmount = buildingStartStats.mineData.gatheringAmount;
        farmGatheringRate = buildingStartStats.farmData.gatheringRate;
        farmGatheringAmount = buildingStartStats.farmData.gatheringAmount;
    }

    private void ModifyBuildingNumber(Building.buildingTypes buildingType, bool increaseNumber)
    {
        int modifier = increaseNumber ? 1 : -1;

        switch (buildingType)
        {
            case Building.buildingTypes.Mine:
                mineNumber += modifier;
                break;

            case Building.buildingTypes.Farm:
                farmNumber += modifier;
                break;
        }

        UIManager.Instance.UpdateBuildingNumber(mineNumber, farmNumber);
    }

    private void BuildManager_OnBuildDestroy(object sender, BuildManager.OnBuildEventArgs e)
    {
        ModifyBuildingNumber(e.buildingType, e.increaseNumber);
    }

    //private void BuildManager_OnDestroy(object sender, BuildManager.OnBuildEventArgs e)
    //{
    //    ModifyBuildingNumber(e.buildingType, e.increaseNumber);
    //}


    //Get resources
    public void GetGold(int goldIncrease)
    {
        goldAmount += goldIncrease;
    }

    public void GetFood(int foodIncrease)
    {
        foodAmount += foodIncrease;
    }
}
