using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public enum buildingTypes
    {
        Mine,
        Farm
    }

    public abstract buildingTypes Type { get; }
}
