using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridPosition gridPosition;
    public bool isGround { get; set; }
    public bool isResource { get; set; }
    public string resourceName { get; set; }
    public int resourceAmount { get; set; }
    public float probability { private get; set; }
    public Material material { get; set; }
    public GameResources gameResources { get; set; }
    public GridObjectType ObjectType { get; set; }

    public Building Building { get; set; }

    public enum GridObjectType
    {
        Water,
        Ground,
        Gold,
        Food,
        Wood
    }

    public GridObject(bool isGround, GridPosition gridPosition) 
    {
        this.isGround = isGround;
        this.gridPosition = gridPosition;
    }

    

    


}
