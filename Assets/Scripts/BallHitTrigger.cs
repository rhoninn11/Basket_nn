using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitTrigger : MonoBehaviour
{

    public delegate void NotifyCallback(Ball obj);

    public NotifyCallback hit;
    private void OnTriggerEnter(Collider other){

        Ball interuptor = other.gameObject.GetComponent<Ball>();

        if(interuptor != null){
            hit(interuptor);
        }
    }
}
