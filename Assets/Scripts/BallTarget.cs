using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BallTarget : MonoBehaviour
{   
    public GameObject topTrigger;
    public GameObject bottomTrigger;

    List<Ball> ballsThatHitsTopTrig = new List<Ball>();
    List<Ball> ballsThatHitsBottomTrig = new List<Ball>();

    public Vector3 GetTargetCords(){
        return transform.position;
    }

    public void ClearTriggerStatus(){
        ballsThatHitsTopTrig.Clear();
        ballsThatHitsBottomTrig.Clear();
    }

    void TopNotification(Ball ball){
        if(ballsThatHitsTopTrig.Contains(ball))
            return;

        if(!ballsThatHitsBottomTrig.Contains(ball))
            ballsThatHitsTopTrig.Add(ball);
    }

    void BottomNotification(Ball ball){
        if(ballsThatHitsBottomTrig.Contains(ball))
            return;

        if(ballsThatHitsTopTrig.Contains(ball)){
            ballsThatHitsBottomTrig.Add(ball);
            ball.HitHandle();
            Debug.Log("propper Hit?");
        }
    }

    void Start(){
        topTrigger.GetComponent<BallHitTrigger>().hit = this.TopNotification;
        bottomTrigger.GetComponent<BallHitTrigger>().hit = this.BottomNotification;
    }
    
}
