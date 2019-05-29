using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct TrajectoryData{
    public Vector3 direction;
    public List<Vector3> trajectoryPoints;

    public TrajectoryData(Vector3 dir, List<Vector3> tPts){
        direction = dir;
        trajectoryPoints = tPts;
    }
}