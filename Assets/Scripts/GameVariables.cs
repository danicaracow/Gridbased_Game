using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Building;


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
        [SerializeField] public int mineNumber { get; private set;}
        [SerializeField] public int farmNumber { get; private set; }

        //Total Resources
        [SerializeField] public int goldAmount { get; private set; }
        [SerializeField] public int foodAmount { get; private set; }


    //References
    private BuildSystem buildSystem;
    [SerializeField] private BuildingStartStats buildingStartStats;

    //Events
    public event EventHandler OnBuildFinished;
    public event EventHandler OnResourceGathered;

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
        buildSystem = GetComponent<BuildSystem>();
        buildSystem.OnBuild += BuildManager_OnBuildDestroy;
        buildSystem.OnDestroy += BuildManager_OnBuildDestroy;

        mineNumber = 0;
        farmNumber = 0;

        goldAmount = 0;
        foodAmount = 0;

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

        OnBuildFinished?.Invoke(this, EventArgs.Empty);
        //PlayerStatsUI.Instance.UpdateBuildingNumber(mineNumber, farmNumber);
    }

    private void BuildManager_OnBuildDestroy(object sender, BuildSystem.OnBuildEventArgs e)
    {
        ModifyBuildingNumber(e.buildingType, e.increaseNumber);
    }

    public void GetResource(int resourceIncrease, buildingTypes buildingType)
    {
        switch (buildingType)
        {
            case Building.buildingTypes.Mine:
                goldAmount += resourceIncrease;
                break;

            case Building.buildingTypes.Farm:
                foodAmount += resourceIncrease;
                break;
        }

        OnResourceGathered?.Invoke(this, EventArgs.Empty);
    }
}
