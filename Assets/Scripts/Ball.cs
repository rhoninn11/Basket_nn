using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    bool hasThrowTimePass = true;
    DateTime startTimePoint;
    float performenceScore = 0;
    public int liveTimeinSeconds = 0;
    private BallTarget target;

    void Update()
    {
        if (!hasThrowTimePass)
            CheckPerformace(Time.deltaTime);
    }

    public void Throw(Vector3 throwVector,BallTarget target)
    {
        this.target = target;

        GetComponent<Rigidbody>().AddForce(throwVector, ForceMode.Impulse);
        startTimePoint = DateTime.Now;
    }

    public void CheckPerformace(float stepTime)
    {
        if (IsLiveTimeExpired())
        {
            hasThrowTimePass = true;
            return;
        }

        if(target != null)
            performenceScore += (target.GetTargetCords() - transform.position).magnitude * stepTime;
    }

    public bool IsLiveTimeExpired()
    {
        return (DateTime.Now - startTimePoint).Seconds > liveTimeinSeconds;
    }

    public void Hit()
    {
        performenceScore -= 5;
        hasThrowTimePass = true;
    }
    public bool HasThrowTimePass(){
        return hasThrowTimePass;
    }
    public float GetPerformanceScore(){
        return performenceScore;
    }


}
