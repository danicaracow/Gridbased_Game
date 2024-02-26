using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public string resourceName;
    public int resourceAmount;
    public float probability;
    public Texture texture;
    public GridObject(string resourceName, int resourceAmount, Texture texture)
    {
        this.resourceName = resourceName;
        this.resourceAmount = resourceAmount;
        this.texture = texture;
    }

    public enum GridObjectType
    {
        Water,
        Ground,
        Gold,
        Food,
        Wood
    }

    public GameResources gameResources { get; set; }
    public GridObjectType ObjectType { get; set; }


}
