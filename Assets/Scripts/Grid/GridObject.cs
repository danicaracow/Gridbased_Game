using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public enum GridObjectType
    {
        Water,
        Ground,
        Gold,
        Food,
        Wood
    }

    public GridObjectType ObjectType { get; set; }


}
