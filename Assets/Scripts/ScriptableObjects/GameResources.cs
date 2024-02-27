using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameResources", menuName = "ScriptableObjects/GameResources")]
public class GameResources : ScriptableObject
{
    [System.Serializable]
    public class Resource
    {
        public string resourceName;
        public int resourceAmount;
        public float probability;
        public Material material;
    }

    [System.Serializable]
    public class Ground
    {
        public float probability;
        public Material material;
    }

    [System.Serializable]
    public class Water
    {
        public Material material;
    }

    
    public Water water = new Water();
    public Ground ground = new Ground();

    public List<Resource> resourceList = new List<Resource>();
    private List<Resource> orderedResourceList;

    public List<Resource> GetOrderedResourceList()
    {
        orderedResourceList = resourceList.OrderByDescending(r => r.probability).ToList();
        return orderedResourceList;
    }




}
