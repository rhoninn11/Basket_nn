using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcessor : MonoBehaviour
{
    public float theHighestPerformanceIndex;
    public float theNearestBasketDistance;
    public float throwPerformanceIndex;
    public float theLowestPerformanceIndex;
    public float theHighestPerformaceAchived;
    public Vector3 ultimateDirection;

    public Vector3 findOptimalThrowDirection(List<TrajectoryData> trajectoryList, BallTarget target, Vector3 throwDirection, out float throwDistance)
    {
        Vector3 targetPosition = target.GetTargetCords();
        Vector3 optimalDirection = Vector3.zero;
        throwDistance = 0;
        bool first = true;

        foreach (var trajectory in trajectoryList)
        {
            float performanceIndex = 0;
            float minialDistance = 1000;

            trajectory.trajectoryPoints.ForEach(p =>
            {
                var distToTarget = Vector3.Distance(p, targetPosition);
                minialDistance = Mathf.Min(distToTarget, minialDistance);
                performanceIndex += distToTarget * Time.fixedDeltaTime;
            });

            if (trajectory.direction == throwDirection)
            {
                throwPerformanceIndex = performanceIndex;
                throwDistance = minialDistance;
                continue;
            }

            if (first)
            {
                first = false;
                theHighestPerformanceIndex = performanceIndex;
                theLowestPerformanceIndex = performanceIndex;
                continue;
            }

            if (performanceIndex < theHighestPerformanceIndex)
            {
                theHighestPerformanceIndex = performanceIndex;
                theNearestBasketDistance = minialDistance;
                optimalDirection = trajectory.direction;
            }

            if (performanceIndex > theLowestPerformanceIndex)
                theLowestPerformanceIndex = performanceIndex;
        }

        Debug.Log($"{theHighestPerformanceIndex}, {theNearestBasketDistance}");
        if (theHighestPerformanceIndex < theHighestPerformaceAchived)
        {
            theHighestPerformaceAchived = theHighestPerformanceIndex;
            ultimateDirection = optimalDirection;
        }

        return ultimateDirection;
    }


}
