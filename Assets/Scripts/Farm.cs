using UnityEngine;

public class Farm : Building
{
    public override buildingTypes Type => buildingTypes.Farm;

    public override void GetResource(int goldIncrease)
    {
        GameVariables.Instance.GetFood(goldIncrease);
    }

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
            GetResource(resourceGatheringAmount);
            nextResourceGatheringTime = Time.time + resourceGatheringRate;
        }
    }
}
