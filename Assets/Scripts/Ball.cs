using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    bool liveTimeExpired = false;
    DateTime startTimePoint;
    public int liveTime = 0;

    public List<V3> trajectory = new List<V3>();

    void FixedUpdate()
    {
        if(startTimePoint != null)
            if(!IsLiveTimeExpired())
                trajectory.Add(new V3(this.transform.position));
    }

    public void Throw(Vector3 throwVector)
    {
        GetComponent<Rigidbody>().AddForce(throwVector, ForceMode.Impulse);
        startTimePoint = DateTime.Now;
    }

    public bool IsLiveTimeExpired()
    {
        return (DateTime.Now - startTimePoint).Seconds > liveTime || liveTimeExpired;
    }

    public void HitHandle()
    {
        liveTimeExpired = true;
    }

}
