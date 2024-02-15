using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingStartStats", menuName = "ScriptableObjects/BuildingStartStats")]
public class BuildingStartStats : ScriptableObject
{
    public float MineGatheringRate;
    public int MineGatheringAmount;

    public float FarmGatheringRate;
    public int FarmGatheringAmount;

}
