using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    bool liveTimeExpired = false;
    private float liveTime = -1;
    public int maxLiveTime;
    public float forceFactor;

    public List<Vector3> trajectory = new List<Vector3>();

    void FixedUpdate()
    {
        if (liveTime != -1)
        {
            liveTime += Time.fixedDeltaTime;
            if (!IsLiveTimeExpired())
                trajectory.Add(this.transform.position);
        }
    }

    public void Throw(Vector3 throwDirection, bool colored)
    {   
        Rigidbody brb = GetComponent<Rigidbody>();
        brb.velocity = Vector3.zero;
        brb.AddForce(throwDirection * forceFactor, ForceMode.Impulse);
        GetComponent<MeshRenderer>().material.color = colored ? new Color(1, 0.5f, 0.5f) : Color.white;
        liveTime = 0;
    }

    public bool IsLiveTimeExpired()
    {
        return liveTime > maxLiveTime || liveTimeExpired;
    }

    public void HitHandle()
    {
        liveTimeExpired = true;
    }

    public void Refresh(){
        liveTimeExpired = false;
        liveTime = -1;
        trajectory = new List<Vector3>();
    }

}
