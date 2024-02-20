using UnityEngine;

public class Mine : Building
{
    public override buildingTypes Type => buildingTypes.Mine;

    private void Start()
    {
        nextResourceGatheringTime = Time.time;

        //This values should be taken from a scriptable object
        resourceGatheringRate = GameVariables.Instance.mineGatheringRate;
        resourceGatheringAmount = GameVariables.Instance.mineGatheringAmount;
    }
    private void Update()
    {
        if (Time.time > nextResourceGatheringTime)
        {
            GetResource(resourceGatheringAmount, buildingTypes.Mine);
            nextResourceGatheringTime = Time.time + resourceGatheringRate;
        }
    }

}
