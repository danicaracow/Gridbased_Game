using UnityEngine;

public class Farm : Building
{
    public override buildingTypes Type => buildingTypes.Farm;

    private void Start()
    {
        nextResourceGatheringTime = Time.time;

        //This values should be taken from a scriptable object
        resourceGatheringRate = GameVariables.Instance.farmGatheringRate;
        resourceGatheringAmount = GameVariables.Instance.farmGatheringAmount;
    }
    private void Update()
    {
        if (Time.time > nextResourceGatheringTime)
        {
            GetResource(resourceGatheringAmount, buildingTypes.Farm);
            nextResourceGatheringTime = Time.time + resourceGatheringRate;
        }
    }

}
