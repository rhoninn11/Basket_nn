using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcessor : MonoBehaviour
{
    public float theHighestPerformanceIndex;
    public float throwPerformanceIndex;
    public float theLowestPerformanceIndex;
    public float theHighestPerformaceAchived;
    public Vector3 ultimateDirection;

    public Vector3 findOptimalThrowDirection(List<TrajectoryData> trajectoryList, BallTarget target, Vector3 throwDirection)
    {
        Vector3 targetPosition = target.GetTargetCords();
        Vector3 optimalDirection = Vector3.zero;
        bool first = true;

        foreach (var trajectory in trajectoryList)
        {
            float performanceIndex = 0;
            
            trajectory.trajectoryPoints.ForEach(p => performanceIndex += Vector3.Distance(p, targetPosition) * Time.fixedDeltaTime);

            if (trajectory.direction == throwDirection)
            {
                throwPerformanceIndex = performanceIndex;
                continue;
            }

            if(first){
                first = false;
                theHighestPerformanceIndex = performanceIndex;
                theLowestPerformanceIndex = performanceIndex;
                continue;
            }

            if(performanceIndex < theHighestPerformanceIndex){
                theHighestPerformanceIndex = performanceIndex;
                optimalDirection = trajectory.direction;
            }

            if(performanceIndex > theLowestPerformanceIndex)
                theLowestPerformanceIndex = performanceIndex;
        }

        if(theHighestPerformanceIndex < theHighestPerformaceAchived){
            theHighestPerformaceAchived = theHighestPerformanceIndex;
            ultimateDirection  = optimalDirection;
        }

        return ultimateDirection;
    }


}
