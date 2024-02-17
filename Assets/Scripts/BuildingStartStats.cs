using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingStartStats", menuName = "ScriptableObjects/BuildingStartStats")]
public class BuildingStartStats : ScriptableObject
{
    [System.Serializable]
    public class BuildingData
    {
        public int gatheringAmount;
        public float gatheringRate;
    }

    public BuildingData mineData = new BuildingData();
    public BuildingData farmData = new BuildingData();

}
