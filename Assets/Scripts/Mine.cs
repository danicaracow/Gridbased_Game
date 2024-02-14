using UnityEngine;

public class Mine : Building
{
    public override buildingTypes Type => buildingTypes.Mine;

    private void Start()
    {
        nextResourceGatheringTime = Time.time;

        //This values should be taken from a scriptable object
        resourceGatheringRate = 5f;
        resourceGatheringAmount = 1;
    }
    private void Update()
    {
        if (Time.time > nextResourceGatheringTime)
        {
            GetResource(resourceGatheringAmount);
            nextResourceGatheringTime = Time.time + resourceGatheringRate;
        }
    }

    public override void GetResource(int goldIncrease)
    {
        GameVariables.Instance.GetGold(goldIncrease);
    }
}
