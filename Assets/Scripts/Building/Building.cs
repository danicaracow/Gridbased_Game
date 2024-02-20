using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Building : MonoBehaviour
{
    public enum buildingTypes
    {
        Mine,
        Farm
    }

    public abstract buildingTypes Type { get; }

    public float nextResourceGatheringTime;
    public float resourceGatheringRate;
    public int resourceGatheringAmount;

    public buildingTypes GetBuildingType()
    {
        return Type;
    }


    public virtual void GetResource(int resourceIncrease, buildingTypes buildingType)
    {
        GameVariables.Instance.GetResource(resourceIncrease, buildingType);
    }
}
